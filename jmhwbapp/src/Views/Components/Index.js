import React, { Fragment, useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getUsersRequest, usersError } from "../../Lib/Actions/users";
import { Navbar } from "../../Components/index";
import { Home } from "./Home";
import { Characters } from "./Character";
import { list } from "../../app/datas";
import { HomeBase } from "./HomeBase";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Switch,
} from "react-router-dom";
import { Callback } from "./Callback";

const App = () => {
  const userList = useSelector((state) => state.users);
  const dispatch = useDispatch();
  const [menuItem, setMenuItem] = useState(0);
  const [isFiltering, setIsFiltering] = useState(false);
  const [listFiltered, SetListFiltered] = useState(false);
  const loadMenuItem = (i) => {
    console.log(i);
    setMenuItem(i);
  };

  //this fonction return filtered list when user write something in search field
  const filterResults = (input) => {
    let fullLilst = list; //normalement on l'utilise quand on a un tableau de tableaux
    let result = fullLilst.filter((user) => {
      const lastName = user.lastName.toLowerCase();
      const term = input.toLowerCase();
      return lastName.indexOf(term) > -1;
    });
    SetListFiltered(result);
    console.log(result);
  };

  useEffect(() => {
    //dispatch(getUsersRequest());
  });
  return (
    <Fragment>
      <Router>
        <Navbar />
        {/*Routes*/}
        <Routes>
          <Route path="/" element={<HomeBase />} />
          <Route
            path="/home"
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
          <Route path="/signin-oidc" element={<Callback />} />
        </Routes>
      </Router>
    </Fragment>
  );
};

export default App;
