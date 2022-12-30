import React, { Fragment, useState, useEffect } from "react";
import { Navbar } from "../../Components/index";
import { Home } from "./Home";
import { Characters } from "./Character";
import { list } from "../../app/datas";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

const App = (props) => {
  const { users } = props;
  const [menuItem, setMenuItem] = useState(0);
  const [isFiltering, setIsFiltering] = useState(false);
  const [listFiltered, SetListFiltered] = useState(false);
  const loadMenuItem = (i) => {
    console.log(i);
    setMenuItem(i);
  };

  //this fonction return filtered list when user write something in search field
  const filterResults = (input) => {
    let fullLilst = list.flat(); //normalement on l'utilise quand on a un tableau de tableaux
    let result = fullLilst.filter((item) => {
      const lastName = item.lastName.toLowerCase();
      const term = input.toLowerCase();
      return lastName.indexOf(term) > -1;
    });
    SetListFiltered(result);
    console.log(result);
  };

  useEffect(() => {
    console.log(isFiltering);
  });

  return (
    <Fragment>
      <Router>
        <Navbar />
        {/*Routes*/}
        <Routes>
          <Route
            path="/"
            element={
              <Home
                list={isFiltering ? listFiltered : list}
                loadMenuItem={loadMenuItem}
                menuItem={menuItem}
                filterResults={filterResults}
                setIsFiltering={setIsFiltering}
              />
            }
          />
          <Route path="/character" element={<Characters />} />
        </Routes>
      </Router>
    </Fragment>
  );
};

export default App;
