export const actions = {
  GET_USERS_REQUEST: "GET_USERS_REQUEST",
  GET_USERS_SUCCESS: "GET_USERS_SUCCESS",
  USERS_ERROR: "USER_ERROR",
};

export function getUsersRequest() {
  return {
    type: actions.GET_USERS_REQUEST,
  };
}

export function getUsersSuccess(users) {
  return {
    type: actions.GET_USERS_SUCCESS,
    payload: users,
  };
}

export function usersError({ error }) {
  return {
    type: actions.USERS_ERROR,
    payload: { error },
  };
}
