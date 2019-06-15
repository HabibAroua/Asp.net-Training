import React, { Component } from 'react';
import {BrowserRouter as Router , Route} from "react-router-dom";

import Navbar from './components/Navbar';
import Landing from './components/Landing';
import Login from './components/Login';
import Admin from './components/Admin';
import Bloc from './components/Bloc';
import AllObjects from './components/AllObjects';
import Categorie from './components/Categorie';
import Casier from './components/Casier'
import Client from './components/Client'
import  Employer from './components/Employer'
import  Fournisseur from './components/Fournisseur'
import Produit from './components/Produit'

class App extends Component {
  render() {
    return (
     <Router>
       <div className="App">
         <Navbar/>
         <Route exact path="/" component={Landing} />
         <div>
           <Route exact path="/bloc" component={Bloc} />
           <Route exact path="/login" component={Login} />
           <Route exact path="/admin" component={Admin} />
           <Route exact path="/allObject" component={AllObjects} />
           <Route exact path="/casier" component={Casier} />
           <Route exact path="/categorie" component={Categorie} />
           <Route exact path="/produit" component={Produit} />
           <Route exact path="/employer" component={Employer} />
           <Route exact path="/client" component={Client} />
           <Route exact path="/fournisseur" component={Fournisseur} />
         </div>
       </div>
     </Router>
    );
  }
}

export default App;
