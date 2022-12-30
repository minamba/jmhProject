import React from "react";
import ReactDOM from "react-dom/client";
import "./Styles/index.css";
// import App from "../src/Views/Components/Index";
import { AppContainer } from "./Views/Containers/index";
import { Provider } from "react-redux";
import store from "./Lib/store";
import axios from "axios";

axios.defaults.withCredentials = false;
axios.defaults.baseURL = "https://localhost:7067";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <Provider store={store}>
    <AppContainer />
  </Provider>
);
