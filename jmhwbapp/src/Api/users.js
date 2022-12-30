import axios from "axios";

export const getUsers = () => {
  return axios.get("/users");
};

// export const createUser = ({ firstName, lastName }) => {
//   return axios.post("/users", {
//     firstName,
//     lastName,
//   });
// };

// export const deleteUser = ({ id }) => {
//   return axios.delete(`/users/${id}`);
// };
