import React, {  useEffect, useState } from 'react';

import { MdAccountBalance } from "react-icons/md";
import { Link } from 'react-router-dom';

const  Home =()=> {
  //static displayName = Home.name;
  const [UserObj, setUserObj] = useState({accountHolderName:"Mr Apollo Carter",displayName:"Apollo",emails:"",addresses:"",telephones:"",noOfAccounts:0,accounts:[{accountHolderName:"",accountNumber:"",accountType:"",accountSubType:"",currentBalance:0,currentBalanceIndicator:""}]});
  const [loading, setLoading] = useState(true); 

  useEffect(()=> {

    fetch(`api/user/get-user`).then((res)=>{
      return res.json();
    })
    .then(data=>{
        //console.log(data)
        setUserObj(data);
      setLoading(false);
    })
  },[])


 
    return (
      
  <div>
        <div className="container">
        <div className="row">
            <div className="col-lg-12 mb-4 mb-sm-5">
                <div className="card card-style1 border-0">
                    <div className="card-body p-1-9 p-sm-2-3 p-md-6 p-lg-7">
                        <div className="row align-items-center">
                            
                            <div className="col-lg-6 px-xl-10">
                                <div className="bg-secondary d-lg-inline-block py-1-9 px-1-9 px-sm-6 mb-1-9 rounded">
                                    <h3 className="h2 text-white mb-0"> {UserObj.accountHolderName}  </h3>
                                    <span className="text-primary">{UserObj.displayName}</span>
                                </div>
                                <ul className="list-unstyled mb-1-9">
                                <li className="mb-2 mb-xl-3 display-28"><span className="display-26 text-secondary me-2 font-weight-600">No of Accounts</span> {UserObj.accounts.length}</li>
                               
                                     <li className="mb-2 mb-xl-3 display-28"><span className="display-26 text-secondary me-2 font-weight-600">Email:</span> {UserObj.emails}</li>
                                    <li className="mb-2 mb-xl-3 display-28"><span className="display-26 text-secondary me-2 font-weight-600">Address:</span> {UserObj.addresses}</li>
                                    <li className="display-28"><span className="display-26 text-secondary me-2 font-weight-600">Phone:</span> {UserObj.telephones}</li>
                                    </ul>
                                <ul className="social-icon-style1 list-unstyled mb-0 ps-0">
                                    <li><a href="#!"><i className="ti-twitter-alt"></i></a></li>
                                    <li><a href="#!"><i className="ti-facebook"></i></a></li>
                                    <li><a href="#!"><i className="ti-pinterest"></i></a></li>
                                    <li><a href="#!"><i className="ti-instagram"></i></a></li>
                                </ul>
                            </div>
                            <div className="col-lg-6 mb-4 mb-lg-0">

                            <div className="padding-top-2x mt-2 hidden-lg-up"></div>
            
            <div className="table-responsive wishlist-table margin-bottom-none">
                <table className="table">
                    <thead>
                        <tr>
                            <th>List of Accounts</th>
                            <th className="text-center"><a className="btn btn-sm btn-outline-danger" href="#"></a></th>
                        </tr>
                    </thead>
                    <tbody>
        {!loading? UserObj.accounts.map((item,index) =>
                        <tr key={index}>
                            <td >
                                <div className="product-item">
                                   <div >
                                    <a className="" href="#">
                                      <MdAccountBalance />
                                      </a>
                                    </div> 
                                    <div className="product-info">
                                        <h4 className="product-title">{item.accountNumber}</h4>
                                        <div className="text-lg text-medium text-muted" style={{color: item.currentBalanceIndicator==="Credit"? "green":"red"}}>${item.currentBalance}</div>
                                        <div>Account Holder Names: 
                                            <div className="d-inline text-success"> {item.accountHolderName}</div>
                                        </div>
                                        <div>Account Type:
                                            <div className="d-inline text-success"> {item.accountType}</div>
                                        </div>
                                        <div>Account Sub Type:
                                            <div className="d-inline text-success"> {item.accountSubType}</div>
                                        </div>
                                   
                                    </div>
                                </div>
                            </td>  <td><Link to={`/fetch-data/${item.accountNumber}`} >View EOD Logs</Link></td>
                            <td className="text-center"><a className="remove-from-cart" href="#" data-toggle="tooltip" title="" data-original-title="Remove item"><i className="icon-cross"></i></a></td>
                        </tr> ):<tr></tr>
}
                    </tbody>
                </table>
            </div>

                                </div>
                        </div>
                    </div>
                </div>
            </div>
          </div>
          </div>





        <div className="col-lg-8">
           
            
        </div> 
    </div> 
    );

  }

  

  export default Home;
