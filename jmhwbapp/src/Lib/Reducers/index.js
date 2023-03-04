import { combineReducers } from "redux";
import UserReducer from "./users";
import UserAuthReducer from "./userAuth";
import { loadUser, reducer as oidcReducer } from "redux-oidc";

export default combineReducers({
  users: UserReducer(),
  userAuth: UserAuthReducer(),
});
