import React from "react";
import ReactDOM from "react-dom/client";
import "./Styles/index.css";
// import App from "../src/Views/Components/Index";
import { AppContainer } from "./Views/Containers/index";
import { Provider } from "react-redux";
import store from "./Lib/store";
import axios from "axios";

axios.defaults.withCredentials = false;
axios.defaults.baseURL = "http://localhost:7067/";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <Provider store={store}>
    <AppContainer />
  </Provider>
);

// var mgr = new UserManager({
//   authority: "https://localhost:5443/",
//   client_id: "interactive",
//   redirect_uri: "http://localhost:3000/signin-oidc",
//   post_logout_redirect_uri: "http://localhost:3000",
//   response_type: "code",
//   scope: "openid profile jmh.api.read",
// });
