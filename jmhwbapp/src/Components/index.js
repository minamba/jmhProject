import React, { Fragment, useState } from "react";
import { Link } from "react-router-dom";

export const Navbar = () => {
  return (
    <nav class="navbar navbar-light bg-light">
      <div class="container-fluid">
        <a class="navbar-brand">Navbar</a>
      </div>
    </nav>
  );
};

export const List = (props) => {
  const { datas, menutItem, filterResults, setIsFiltering } = props;
  const users = datas;
  return (
    <Fragment>
      <div>
        <div>
          <form class="col-4 align-content-start mb-2">
            <input
              class="form-control me-2"
              type="search"
              placeholder="Rechercher"
              aria-label="Search"
              onChange={(e) => {
                setIsFiltering(e.target.value.length > 0); //it return true ou or false if the field contain some values
                filterResults(e.target.value);
              }}
            />
          </form>
        </div>
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
                    <td>{user.lastName}</td>
                    <td>{user.firstName}</td>
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
      </div>
    </Fragment>
  );
};

export const SideMenu = (props) => {
  const { loadMenuItem, menuItem } = props;
  return (
    <div class="col-auto col-md-3 col-xl-2 px-sm-2 px-0 bg-light">
      <div class="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
        <a
          href="/"
          class="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-white text-decoration-none"
        >
          <span class="fs-5 d-none d-sm-inline menu-title">Menu</span>
        </a>
        <ul
          class="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start"
          id="menu"
        >
          <li class="nav-item">
            <a
              href="#"
              class="nav-link align-middle px-0"
              onClick={() => loadMenuItem(0)}
            >
              <i class="fs-4 bi-house"></i>{" "}
              <span class="ms-1 d-none d-sm-inline">Acceuil</span>
            </a>
          </li>
          <li>
            <a
              onClick={() => loadMenuItem(1)}
              href="#submenu1"
              data-bs-toggle="collapse"
              class="nav-link px-0 align-middle"
            >
              <i class="fs-4 bi-speedometer2"></i>{" "}
              <span class="ms-1 d-none d-sm-inline">Utilisateurs</span>{" "}
            </a>
            <ul
              class="collapse show nav flex-column ms-1"
              id="submenu1"
              data-bs-parent="#menu"
            >
              <li class="w-100">
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(2)}
                >
                  {" "}
                  <span class="d-none d-sm-inline">Liste</span>{" "}
                </a>
              </li>
              <li class="w-100">
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(3)}
                >
                  {" "}
                  <span class="d-none d-sm-inline">
                    Ajout d'un utilisateur
                  </span>{" "}
                </a>
              </li>
            </ul>
          </li>
          <li>
            <a
              onClick={() => loadMenuItem(4)}
              href="#submenu2"
              data-bs-toggle="collapse"
              class="nav-link px-0 align-middle "
            >
              <i class="fs-4 bi-bootstrap"></i>{" "}
              <span class="ms-1 d-none d-sm-inline">Personnages</span>
            </a>
            <ul
              class="collapse nav flex-column ms-1"
              id="submenu2"
              data-bs-parent="#menu"
            >
              <li class="w-100">
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(5)}
                >
                  {" "}
                  <span class="d-none d-sm-inline">Liste</span>{" "}
                </a>
              </li>
              <li>
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(6)}
                >
                  {" "}
                  <span class="d-none d-sm-inline">
                    Ajouter un personnage
                  </span>{" "}
                </a>
              </li>
            </ul>
          </li>
          <li>
            <a
              onClick={() => loadMenuItem(7)}
              href="#submenu3"
              data-bs-toggle="collapse"
              class="nav-link px-0 align-middle"
            >
              <i class="fs-4 bi-grid"></i>
              <span class="ms-1 d-none d-sm-inline">Questions/Reponses</span>
            </a>
            <ul
              class="collapse nav flex-column ms-1"
              id="submenu3"
              data-bs-parent="#menu"
            >
              <li class="w-100">
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(8)}
                >
                  <span class="d-none d-sm-inline">Liste des questions</span>
                </a>
              </li>
              <li>
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(9)}
                >
                  <span class="d-none d-sm-inline">Liste des réponses</span>
                </a>
              </li>
              <li>
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(10)}
                >
                  <span class="d-none d-sm-inline">Ajouter une question</span>
                </a>
              </li>
              <li>
                <a
                  href="#"
                  class="nav-link px-0"
                  onClick={() => loadMenuItem(11)}
                >
                  <span class="d-none d-sm-inline">Ajouter une réponse</span>
                </a>
              </li>
            </ul>
          </li>
          <li>
            <a
              href="#"
              class="nav-link px-0 align-middle"
              onClick={() => loadMenuItem(12)}
            >
              <i class="fs-4 bi-people"></i>{" "}
              <span class="ms-1 d-none d-sm-inline">Scores</span>{" "}
            </a>
          </li>
        </ul>
        <hr />
      </div>
    </div>
  );
};
