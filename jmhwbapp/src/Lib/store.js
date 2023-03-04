import { createStore, applyMiddleware } from "redux";
import Reducers from "../Lib/Reducers/users";
import createSagaMiddleware from "redux-saga";
import rootSaga from "./sagas";
// import { loadUser } from "redux-oidc";

const sagaMiddlaware = createSagaMiddleware();
const store = createStore(Reducers, applyMiddleware(sagaMiddlaware));
sagaMiddlaware.run(rootSaga);

export default store;
