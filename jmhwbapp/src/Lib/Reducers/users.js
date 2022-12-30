import { actions } from "../Actions/users";

const initialState = {
  users: [],
  error: "",
};

export default function UserReducer(state = initialState, action) {
  switch (action.type) {
    case actions.GET_USERS_SUCCESS:
      return {
        ...state,
        users: action.payload.users,
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
