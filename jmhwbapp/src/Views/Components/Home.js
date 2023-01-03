import React from "react";
import { List, SideMenu } from "../../Components/index";
import { useState } from "react";

export const Home = (props) => {
  const { list, loadMenuItem, menuItem, filterResults, setIsFiltering } = props;
  return (
    <div className="container mt-5">
      <div>
        <h1 className="align-center">
          Bienvenue sur la page d'administration de l'application "J'aime mon
          histoire"
        </h1>
      </div>
      <div className="row">
        <div class="container-fluid">
          <div class="row flex-nowrap">
            <SideMenu loadMenuItem={loadMenuItem} menuItem={menuItem} />
            <List
              datas={list}
              filterResults={filterResults}
              setIsFiltering={setIsFiltering}
            />
          </div>
        </div>
      </div>
    </div>
  );
};
