import React ,{Component} from 'react';
import jwt_decode from 'jwt-decode';
import './style.css';
import axios from "axios";

class Admin extends Component
{
    register(newUser)
    {
        return axios
            .post('http://localhost:5000/users/register',
                {
                    Nom: newUser.first_name,
                    Prenom: newUser.last_name,
                    Cin: newUser.email,
                    Email: newUser.password,
                    Password:newUser.password
                })
            .then(res => {
                if (res.data == "x1") {
                    window.Swal.fire
                    (
                        'Good job',
                        "User added ..",
                        'success'
                    )
                } else {
                    if (res.data == "x2") {
                        window.Swal.fire
                        (
                            'Good job',
                            "User already exists",
                            'error'
                        )
                    }
                }
            })
    }

    delete(id) {
        return axios
            .post('http://localhost:5000/users/DeleteUser', {
                id: id
            })
            .then(res => {
                window.Swal.fire(
                    'Deleted!',
                    res.data,
                    'success'
                )
            })

    }


    constructor() {
        super();
        this.state =
            {
                Nom: '',
                Prenom: '',
                Cin: '',
                Email: '',
                Password: '',
                admins: [] //users
            }

        this.onChange = this.onChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    onDelete(id, e) {
        window.Swal.fire({
            title: 'Are you sure?',
            text: "Do you want to delete this user?",
            type: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                this.delete(id).then(res => {

                })
                window.location.reload();
            }
        })
    }

    onChange(e) {
        this.setState({[e.target.name]: e.target.value})
    }

    IsEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    onSubmit(e) {
        e.preventDefault();
        const user =
            {
                Nom: this.state.Nom,
                Prenom: this.state.Prenom,
                Cin: this.state.Cin,
                Email: this.state.Email,
                Password: this.state.Password
            }
            this.register(user).then(res => {

            })
              window.location.reload();


    }


    componentDidMount()
    {
        axios.get("http://localhost:53470/api/admin/all")
            .then(res=>
            {
                this.setState(
                    {
                        admins : res.data
                    }
                )
            });
    }

    render()
    {
        const {admins}=this.state;
        const adminList=admins.map(admin=>
        {
            return (
                <tr>
                    <td>{admin.Id}</td>
                    <td>{admin.Nom}</td>
                    <td>{admin.Prenom}</td>
                    <td>{admin.Cin}</td>
                    <td>{admin.Email}</td>
                    <td>
                        <a href="#" className="btn btn-primary a-btn-slide-text"    onClick={this.onDelete.bind(this, admin.Id)}
                        >
                            <span className="glyphicon glyphicon-trash" aria-hidden="true"></span>
                            <span><strong>Delete</strong></span>
                        </a>
                    </td>
                </tr>
            )
        })
        return (
            <div className="container">
                <div className="row">
                    <div className="col-md mt-8 mx-auto">
                        <form noValidate onSubmit={this.onSubmit}>
                            <div className="form-group col-lg-10 col-md-3 col-sm-xs-12">
                                <center>
                                    <h1 className="h3 mb-6 font-weight-normal">
                                        Ajouter un admin
                                    </h1>
                                </center>
                                <label htmlFor="Nom">
                                    Nom
                                </label>
                                <input type="text"
                                       className="form-control"
                                       name="Nom"
                                       placeholder="Donnez votre nom"
                                       value={this.state.Nom}
                                       onChange={this.onChange}
                                />
                            </div>
                            <div className="form-group col-lg-10 col-md-3 col-sm-xs-12">
                                <label htmlFor="Prenom">
                                    Prenom
                                </label>
                                <input type="text"
                                       className="form-control"
                                       name="Prenom"
                                       placeholder="Donnez votre prenom"
                                       value={this.state.Prenom}
                                       onChange={this.onChange}
                                />
                            </div>
                            <div className="form-group col-lg-10 col-md-3 col-sm-xs-12">
                                <label htmlFor="Cin">
                                    Cin
                                </label>
                                <input type="text"
                                       className="form-control"
                                       name="Cin"
                                       placeholder="Donnez votre Cin"
                                       value={this.state.Cin}
                                       onChange={this.onChange}
                                />
                            </div>
                            <div className="form-group col-lg-10 col-md-3 col-sm-xs-12">
                                <label htmlFor="Email">
                                    Email
                                </label>
                                <input type="text"
                                       className="form-control"
                                       name="Email"
                                       placeholder="Donnez votre Email"
                                       value={this.state.Email}
                                       onChange={this.onChange}
                                />
                            </div>
                            <div className="form-group col-lg-10 col-md-3 col-sm-xs-12">
                                <label htmlFor="password">
                                    Password
                                </label>
                                <input type="password"
                                       className="form-control"
                                       name="Password"
                                       placeholder="Donnez votre mot de passe"
                                       value={this.state.Password}
                                       onChange={this.onChange}
                                />
                            </div>
                            <div className="form-group col-lg-4">
                                <table>
                                    <tr>
                                        <th>
                                            <button type="submit"
                                                    className="btn btn-lg btn-primary btn-block "
                                            >
                                                Add new user
                                            </button>
                                        </th>
                                    </tr>
                                </table>
                            </div>
                        </form>
                    </div>
                    <div className="col-md mt-8 mx-auto">
                        <div className="form-group col-lg-8 col-md-3 col-sm-xs-12">
                            <center>
                                <h4>List of users</h4>
                            </center>
                            <table className="table table-striped">
                                <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Nom</th>
                                    <th>Prenom</th>
                                    <th>Cin</th>
                                    <th>Email</th>
                                    <th>Supprimer</th>
                                    <th>Modifier</th>
                                </tr>
                                </thead>
                                <tbody>
                                {adminList}
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

}
export default Admin;
