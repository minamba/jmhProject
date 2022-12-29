import React from "react";
import { List } from "../../Components/index";

export const Home = () => {
  //   const { list } = props;
  return (
    <div className="container mt-5">
      <div>
        <h1 className="align-center">
          Bienvenue sur la page d'administration de l'application "J'aime mon
          histoire"
        </h1>
      </div>
      <div className="row">
        <List />
      </div>
    </div>
  );
};
