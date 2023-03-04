import axios from "axios";
import userManager from "../utils/UserManager";
import React, { Fragment, useState } from "react";

// const header = {
//   headers: {
//     Authorization: "Bearer" + user.access_token,
//   },
// };

export const getUsers = () => {
  return axios.get("/users");
};

// var mgr = new UserManager({
//   authority: "https://localhost:5443/",
//   client_id: "interactive",
//   redirect_uri: "http://localhost:3000/signin-oidc",
//   post_logout_redirect_uri: "http://localhost:3000",
//   response_type: "code",
//   scope: "openid profile jmh.api.read",
// });

// export const getUsers = () => {
//   return axios.get("/users", { headers: { Authorization: `Basic ${token}` } });
// };

// //when the application start, if there is a authentication session, give me the user
// useEffect(() => {
//   mgr.getUser().then((user) => {
//     if (user) {
//       fetch("https://localhost:7067/users", {
//         headers: {
//           Authorization: "Bearer " + user.access_token,
//         },
//       })
//         .then((resp) => resp.json())
//         .then((data) => setState({ user, data }));
//     }
//     //console.log(user.access_token);
//   });
// }, []);

// export const createUser = ({ firstName, lastName }) => {
//   return axios.post("/users", {
//     firstName,
//     lastName,
//   });
// };

// export const deleteUser = ({ id }) => {
//   return axios.delete(`/users/${id}`);
// };
