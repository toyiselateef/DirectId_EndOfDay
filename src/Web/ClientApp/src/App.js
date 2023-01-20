import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import Home  from './components/Home'; 
import  Analytics  from './components/Analytics'; 

import './custom.css' 

export default class App extends Component {
  static displayName = App.name;

  render () { 
    return (

      <Layout>
        <Switch>
        <Route exact path='/' component={Home} />
        <Route path='/fetch-data/:accno' component={Analytics} />
        </Switch>
      </Layout>
 
    );
  }

  
}
