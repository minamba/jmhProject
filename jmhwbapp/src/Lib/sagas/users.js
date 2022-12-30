import {
  takeEvery,
  takeLatest,
  take,
  call,
  fork,
  put,
} from "redux-saga/effects";
import * as actions from "../../Lib/Actions/users";
import * as api from "../../Api/users";

function* getUsers() {
  try {
    const result = yield call(api.getUsers); //call est une promess, quoi qu'il arrive, quand il recevra une information il l'a mettre dans result
    // debugger;
    yield put(actions.getUsersSuccess({ users: result.data.users }));
  } catch (e) {
    // debugger;
    yield put(
      actions.usersError({
        error: "An error occured when trying to get users ",
      })
    );
  }
  return true;
}

// function* createUser(action) {
//   try {
//     // debugger;
//     yield call(api.createUser, {
//       firstName: action.payload.firstName,
//       lastName: action.payload.lastName,
//     });
//     //console.log(action);
//     yield call(getUsers);
//   } catch (e) {
//     yield put(
//       actions.usersError({
//         error: "An error occured when trying to create the user ",
//       })
//     );
//   }
// }

// function* deleteUser(id) {
//   try {
//     yield call(api.deleteUser, id);
//     yield call(getUsers);
//   } catch (e) {
//     // console.log("puirée");
//     yield put(
//       actions.usersError({
//         error: "An error occured when trying to delete the user ",
//       })
//     );
//   }
// }

function* watchGetUsersRequest() {
  yield takeEvery(actions.actions.GET_USERS_REQUEST, getUsers);
}

// function* watchCreatetUserRequest() {
//   yield takeLatest(actions.actions.CREATE_USER_REQUEST, createUser);
// }

// function* watchDeletetUserRequest() {
//   while (true) {
//     const action = yield take(actions.actions.DELETE_USER_REQUEST);
//     yield call(deleteUser, {
//       id: action.payload.id,
//     });
//   }
// }

const usersSagas = [
  fork(watchGetUsersRequest),
  //   fork(watchCreatetUserRequest),
  //   fork(watchDeletetUserRequest),
];
export default usersSagas;
