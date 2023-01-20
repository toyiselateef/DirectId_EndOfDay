import React from 'react';


const EODTable =({eodData, loading}) => {
  return ( loading
    ? <p><em>Loading...</em></p>
    : (
    <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Date</th>
        
          <th>Balance Type</th>
          <th>Balance</th>
        </tr>
      </thead>
      <tbody>
        {eodData.map((eod,index) =>
          <tr key={index}>
            <td>{eod.day}</td>
            <td>{eod.eodBalanceType}</td>
            <td style={{color: (eod.eodBalanceType ==='Credit' ? "green":"red")}}>{eod.eodBalance }</td>
            
          </tr>
        )}
      </tbody>
    </table>)
  );
}


export default EODTable;