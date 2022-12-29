import React from "react";
import { Link } from "react-router-dom";

export const Navbar = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <a className="navbar-brand" href="#">
        Navbar
      </a>
      <button
        className="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>

      <div className="collapse navbar-collapse" id="navbarSupportedContent">
        <ul className="navbar-nav mr-auto">
          <li className="nav-item active">
            <a className="nav-link" href="#">
              Home <span className="sr-only">(current)</span>
            </a>
          </li>

          <li className="nav-item dropdown">
            <a
              className="nav-link dropdown-toggle"
              href="#"
              id="navbarDropdown"
              role="button"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >
              Dropdown
            </a>
            <div className="dropdown-menu" aria-labelledby="navbarDropdown">
              {/* <Link className="dropdown-item" to="/">
                Action
              </Link>
              <Link className="dropdown-item" to="/">
                Another action
              </Link>
              <div className="dropdown-divider"></div>
              <Link className="dropdown-item" to="/">
                Something else here
              </Link> */}
            </div>
          </li>
        </ul>
        <form className="form-inline my-2 my-lg-0 ">
          <input
            className="form-control mr-sm-2"
            type="search"
            placeholder="Search"
            aria-label="Search"
          />
        </form>
      </div>
    </nav>
  );
};

export const List = (props) => {
  const { datas } = props;
  const users = datas;
  return (
    <div className="">
      <table className="table table-responsive-sm table-striped table-hover ">
        <thead>
          <tr>
            <th>Nom</th>
            <th>Prénom</th>
            <th>Pseudo</th>
            <th>Sexe</th>
            <th>Niveau</th>
            <th>Mail</th>
            <th>Rôle</th>
            <th>Modifier</th>
            <th>Supprimer</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user, index) => {
            return (
              <tr key={index}>
                <td>{user.firstName}</td>
                <td>{user.lastName}</td>
                <td>{user.pseudonym}</td>
                <td>{user.sexe}</td>
                <td>{user.level}</td>
                <td>{user.mail}</td>
                <td>{user.role}</td>
                <td>
                  <button type="button" class="btn btn-warning">
                    <i class="fa-solid fa-pen"></i>
                  </button>
                </td>
                <td>
                  <button type="button" class="btn btn-danger">
                    <i class="fa-solid fa-xmark"></i>
                  </button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};
