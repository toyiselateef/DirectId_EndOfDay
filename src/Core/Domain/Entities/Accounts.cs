
using System;

namespace Domain.Entities
{
    public class Accounts
    {
        private decimal balance;
        private readonly object balanceLock = new object();
        private decimal credits;
        private decimal debits;

        public Accounts(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void Deduct(decimal amount)
        {
            lock (balanceLock)
            {
                if (balance < amount)
                {
                    throw new Exception("Insufficient funds");
                }
                balance -= amount;
                debits += amount;
            }
        }

        public void Add(decimal amount)
        {
            lock (balanceLock)
            {
                balance += amount;
                credits += amount;
            }
        }

        public decimal GetBalance()
        {
            lock (balanceLock)
            {
                return balance;
            }
        }

        public decimal GetCredits()
        {
            lock (balanceLock)
            {
                return credits;
            }
        }

        public decimal GetDebits()
        {
            lock (balanceLock)
            {
                return debits;
            }
        }

    }

}