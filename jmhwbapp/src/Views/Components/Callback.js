import { UserManager } from "oidc-client";
import { useEffect } from "react";

export const Callback = () => {
  useEffect(() => {
    var mgr = new UserManager({ response_mode: "query" });
    mgr.signinRedirectCallback().then(() => (window.location.href = "/"));
  }, []);
  return <p>Loading...</p>;
};

// export const Callback = () => {
//   useEffect(() => {
//     <CallbackComponent
//       userManager={userManagerConfig}
//       successCallback={() => {
//         this.props.dispatch(push("/"));
//       }}
//       errorCallback={(error) => {
//         this.props.dispatch(push("/homeBase"));
//         console.error(error);
//       }}
//     >
//       <div>Redirecting...</div>
//     </CallbackComponent>;
//   }, []);
//   return <p>Loading...</p>;
// };
