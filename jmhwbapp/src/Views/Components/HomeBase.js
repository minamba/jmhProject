import { UserManager } from "oidc-client";
import React, { useEffect } from "react";
import { useState } from "react";

export const HomeBase = () => {
  const [state, setState] = useState(null);
  // debugger;
  var mgr = new UserManager({
    authority: "https://localhost:5443/",
    client_id: "interactive",
    // client_secret: "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
    redirect_uri: "http://localhost:3000/signin-oidc",
    post_logout_redirect_uri: "http://localhost:3000",
    response_type: "code",
    scope: "openid profile jmh.api.read",
  });

  //when the application start, if there is a authentication session, give me the user
  useEffect(() => {
    mgr.getUser().then((user) => {
      if (user) {
        fetch("https://localhost:7067/users", {
          Headers: {
            Authorization: "Bearer" + user.access_token,
          },
        })
          .then((resp) => resp.json())
          .then((data) => setState({ user, data }));
      }
    });
  }, []);

  return (
    <div className="container mt-5">
      {state ? (
        <>
          <h3>Welcome {state?.user?.profile?.sub}</h3>
          <pre>{JSON.stringify(state?.data, null, 2)}</pre>
          <button onClick={() => mgr.signoutRedirect()}>Log out</button>
        </>
      ) : (
        <>
          <h3>J'aime mon histoire App</h3>
          <button onClick={() => mgr.signinRedirect()}>Login</button>
        </>
      )}
    </div>
  );
};
