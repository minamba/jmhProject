import { createUserManager } from "redux-oidc";

const userManagerConfig = {
  // client_id: "interactive",
  // redirect_uri: "http://localhost:3000/signin-oidc",
  // authority: "https://localhost:5443",
  // post_logout_redirect_uri: "http://localhost:3000/",
  // response_type: "code",
  // scope: "openid profile jmh.api.read",
};

const userManager = createUserManager(userManagerConfig);
export default userManager;
