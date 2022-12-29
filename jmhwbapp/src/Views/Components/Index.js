import React, { Fragment } from "react";
import { Navbar } from "../../Components/index";
import { Home } from "./Home";
import { list } from "../../app/datas";

const App = () => {
  return (
    <Fragment>
      <Navbar />
      <Home />
    </Fragment>
  );
};

export default App;
