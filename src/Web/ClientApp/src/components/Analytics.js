import React, { useEffect, useState } from 'react'; 
import styled from "styled-components";
import  EODTable  from "./EODTable";
import { BsFillArrowDownCircleFill } from "react-icons/bs";
import { BsFillArrowUpCircleFill } from "react-icons/bs";
import { AiOutlineMore } from "react-icons/ai";
import { BiTransfer } from "react-icons/bi"; 

import '../index.css'
import {useParams } from 'react-router-dom';


const  Analytics =()=> {

    const [CDObj, setCDObj] = useState({ eodBalanceDetails:[],closingBalance:0,totalCredits:0, totalDebits: 0});
    const [loading, setLoading] = useState(true);
    const {accno} = useParams();
    const custACCNumber =  accno.trim() || '';

    useEffect(()=> {

      fetch(`api/account/eod-balances/${custACCNumber}`).then((res)=>{
        return res.json();
      })
      .then(data=>{
        setCDObj(data);
        setLoading(false);
      })
    },[])

    
    //const {query,search} = useLocation();
     
    
    const Section = styled.section`
  display: flex;
  grid-template-columns: repeat(4, 1fr);
  justify-content: space-between;
  margin: 0 60px;
  .analytic {
    justify-content: space-between;
    padding: 1rem 2rem 1rem 2rem;
    border-radius: 1rem;
    color: black;
    background-color: white;
    border-style: solid;
    border-color: hsla(89, 43%, 51%, 0.3);
    justify-content: space-evenly;
    align-items: center;
    transition: 0.5s ease-in-out;
    width: 170px;

    .design {
      display: flex;
      align-items: center;

      .logo {
        background-color: white;
        display: flex;
        justify-content: center;
        align-items: center;

        svg {
          font-size: 2rem;
        }
      }
      .action {
        margin-left: 80px;
        svg {
          font-size: 1.5rem;
        }
      }
    }
    .transfer {
      margin-top: 20px;
      color: grey;
    }
    .money {
      margin-top: 20px;
    }
  }
`;


  return (
      
      <><Section>
    
        <div className="analytic ">
          <div className="design">
            <div className="logo">
              <BiTransfer />
            </div>
            <div className="action">
              <AiOutlineMore />
            </div>
          </div>
          <div className="transfer">
            <h6>Current </h6>
            <h6>Balance</h6>
          </div>
          <div className="money">
            <h5>${CDObj.closingBalance?CDObj.closingBalance:0}</h5>
          </div>
        </div>
        <div className="analytic ">
          <div className="design">
            <div className="logo">
              <BsFillArrowDownCircleFill style={{ color: "green" }} />
            </div>
            <div className="action">
              <AiOutlineMore />
            </div>
          </div>
          <div className="transfer">
            <h6>Total </h6>
            <h6>Credits</h6>
          </div>
          <div className="money">
            <h5>${CDObj.totalCredits?CDObj.totalCredits:0}</h5>
          </div>
        </div>
        <div className="analytic ">
          <div className="design">
            <div className="logo">
              <BsFillArrowUpCircleFill style={{ color: "red" }} />
            </div>
            <div className="action">
              <AiOutlineMore />
            </div>
          </div>
          <div className="transfer">
            <h6>Total </h6>
            <h6>Debits</h6>
          </div>
          <div className="money">
            <h5>${CDObj.totalDebits?CDObj.totalDebits:0}</h5>
          </div>
        </div>
      </Section>
    <div></div>
    <div>
      <EODTable eodData={
       CDObj.eodBalanceDetails }
       loading={loading}/>
    </div>
      </>
    );
  }

  



export default Analytics;