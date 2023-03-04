import React, { useEffect } from "react";
import { List, SideMenu } from "../../Components/index";
import { useState } from "react";
import userManager from "../../utils/UserManager";
import { useDispatch, useSelector } from "react-redux";
import { getUsersRequest, usersError } from "../../Lib/Actions/users";

export const Home = (props) => {
  const { list, loadMenuItem, menuItem, filterResults, setIsFiltering } = props;
  const [state, setState] = useState(null);
  // const userList = useSelector((state) => state.users);
  const dispatch = useDispatch();

  //   userManager.getUser().then((user) => {
  //     if (user) {
  //       fetch("https://localhost:7067/users", {
  //         headers: {
  //           Authorization: "Bearer " + user.access_token,
  //         },
  //       })
  //         .then((resp) => resp.json())
  //         .then((data) => setState({ user, data }));
  //     }

  // useEffect(() => {
  //   dispatch(getUsersRequest());
  // });

  return (
    <div className="container mt-5">
      {list !== null ? (
        <>
          <div>
            <h1 className="align-center">
              Bienvenue sur la page d'administration de l'application "J'aime
              mon histoire"
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
              ²
            </div>
          </div>
        </>
      ) : (
        <>
          <h3>J'aime mon histoire App</h3>
          <button onClick={() => userManager.signinRedirect()}>Login</button>
          {/* {mgr.signinRedirect()} */}
        </>
      )}
    </div>
  );
};
