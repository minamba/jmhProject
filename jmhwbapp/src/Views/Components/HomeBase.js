import { UserManager } from "oidc-client";
import React, { useEffect } from "react";
import { useState } from "react";
import userManager from "../../utils/UserManager";
import { useDispatch, useSelector } from "react-redux";
import { getUsersRequest, usersError } from "../../Lib/Actions/users";

export const HomeBase = () => {
  // const [state, setState] = useState(null);
  // // debugger;
  // // var mgr = new UserManager({
  // //   authority: "https://localhost:5443/",
  // //   client_id: "interactive",
  // //   redirect_uri: "http://localhost:3000/signin-oidc",
  // //   post_logout_redirect_uri: "http://localhost:3000",
  // //   response_type: "code",
  // //   scope: "openid profile jmh.api.read",
  // // });
  // // when the application start, if there is a authentication session, give me the user
  // useEffect(() => {
  //   userManager.getUser().then((user) => {
  //     if (user) {
  //       fetch("https://localhost:7067/users", {
  //         headers: {
  //           Authorization: "Bearer " + user.access_token,
  //         },
  //       })
  //         .then((resp) => resp.json())
  //         .then((data) => setState({ user, data }));
  //     }
  //     //console.log(user.access_token);
  //   });
  // }, []);
  // // useEffect(() => {
  // //   dispatch(getUsersRequest());
  // // });
  // return (
  //   <div className="container mt-5">
  //     {state ? (
  //       <>
  //         <h3>Welcome {state?.user?.profile?.sub}</h3>
  //         <pre>{JSON.stringify(state?.data, null, 2)}</pre>
  //         <button onClick={() => userManager.signoutRedirect()}>Log out</button>
  //       </>
  //     ) : (
  //       <>
  //         <h3>J'aime mon histoire App</h3>
  //         <button onClick={() => userManager.signinRedirect()}>Login</button>
  //         {/* {mgr.signinRedirect()} */}
  //       </>
  //     )}
  //   </div>
  // );
};
