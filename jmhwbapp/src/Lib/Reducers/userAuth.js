import { actions } from "../Actions/userAuth";

const initialState = {
  user: null,
  error: "",
};

export default function UserAuthReducer(state = initialState, action) {
  switch (action.type) {
    case actions.GET_USER:
      return {
        ...state,
        user: action.payload.users,
      };
    case actions.USERS_ERROR:
      //console.log(action.payload.error);
      return {
        ...state,
        error: action.payload.error,
      };
    default:
      return state;
  }
}
