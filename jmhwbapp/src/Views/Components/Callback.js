import { UserManager } from "oidc-client";
import { useEffect } from "react";

export const Callback = () => {
  useEffect(() => {
    var mgr = new UserManager({ response_mode: "query" });
    mgr.signinRedirectCallback().then(() => (window.location.href = "/"));
  }, []);
  return <p>Loading...</p>;
};
