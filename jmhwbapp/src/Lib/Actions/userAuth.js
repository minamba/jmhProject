export const actions = {
  GET_USER: "GET_USER",
  //   GET_USER_TOKEN: "GET_USERS_REQUEST",
  //   GET_USER_REFRESH_TOKEN: "GET_USERS_SUCCESS",
  USER_ERROR: "USER_ERROR",
};

export function getUserInfo(user) {
  return {
    type: actions.GET_USER,
    payload: user,
  };
}

// export function getUsersSuccess(users) {
//   return {
//     type: actions.GET_USERS_SUCCESS,
//     payload: users,
//   };
// }

export function usersError({ error }) {
  return {
    type: actions.USERS_ERROR,
    payload: { error },
  };
}
