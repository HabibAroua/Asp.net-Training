import React , {Component} from 'react';
import {Link , withRouter} from 'react-router-dom';
import jwt_decode from "jwt-decode";
import axios from "axios";

class Navbar extends Component
{



    render()
    {
        const userLink = (
            <ul className="navbar-nav">
                <li className="nav-item">
                    <Link to="/admin" className="nav-link">
                        Gestion Admin
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/bloc" className="nav-link">
                        Gestion Bloc
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/categorie" className="nav-link">
                        Gestion Categorie
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/casier" className="nav-link">
                        Gestion Casier
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/client" className="nav-link">
                        Gestion Client
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/employer" className="nav-link">
                        Gestion Employer
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/fournisseur" className="nav-link">
                        Gestion Fournisseur
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/produit" className="nav-link">
                        Gestion Produit
                    </Link>
                </li>

            </ul>
        )
        return(
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark rounded">
                <button className="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target="#navbar1"
                        aria-controls="navbar1"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                >
                    <span className="navbar-toggle-icon"></span>
                </button>
                <div className="collapse navbar-collapse justify-content-md-center" id="navbar1">
                    <div>
                        <ul className="navbar-nav">
                            <li className="navbar-nav">
                                <Link to="/" className="nav-link">
                                    Home
                                </Link>
                            </li>
                        </ul>
                    </div>
                    {userLink}
                </div>
            </nav>
        )
    }
}
export default withRouter(Navbar)