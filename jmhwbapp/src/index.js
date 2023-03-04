import React, { useEffect } from "react";
import ReactDOM from "react-dom/client";
import "./Styles/index.css";
// import App from "../src/Views/Components/Index";
import { AppContainer } from "./Views/Containers/index";
import { Provider } from "react-redux";
import store from "./Lib/store";
import axios from "axios";
import userManager from "./utils/UserManager";

axios.defaults.withCredentials = false;
axios.defaults.baseURL = "https://localhost:7067/";

userManager.getUser().then((user) => {
  if (user) {
    axios.defaults.headers.common["Authorization"] =
      "Bearer " + user.access_token; //Pour la recuperation du token
    console.log("mon token : " + user.access_token);
  }
});

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <Provider store={store}>
    <AppContainer />
  </Provider>
);
