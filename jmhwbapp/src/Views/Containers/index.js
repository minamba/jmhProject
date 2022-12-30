import { connect } from "react-redux";
import App from "../../Views/Components/Index";

export const AppContainer = connect(
  function mapStateToProps(state) {
    return {
      users: state.users,
      error: state.error,
    };
  }
  // function mapDispatchToProps(dispatch) {
  //   //dans le cas ou j'ai besoin de passer les actions en tant que props sinon je peux utliser le hook useDispatch directement dans mon composant
  //   return {
  //     onGetUsers: (items) => dispatch(getUsersSuccess(items)),
  //   };
  // }
)(App);
