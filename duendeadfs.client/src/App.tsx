import { RouterProvider, createBrowserRouter } from "react-router-dom";
import Home from "./components/Home";
import About from "./components/layout/About";
import Signin from "./components/layout/Signin";
import { AuthProvider } from "oidc-react";
import Weather from "./components/layout/Weather";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
    children: [
      {
        path: "",
        element: <Weather />,
      },
      {
        path: "/about",
        element: <About />,
      },
      {
        path: "/sign-in",
        element: <Signin />,
      },
    ],
  },
]);

const oidcConfig = {
  onSignIn: (user: unknown) => {
    console.log(user);
  },
  authority: "https://localhost:5001",
  clientId: "interactive.public.short",
  clientSecret: "secret",
  redirectUri: `${window.location.origin}`
};


function App() {

  return (
    <AuthProvider {...oidcConfig} >
      <RouterProvider router={router} />
    </AuthProvider>
  );
}

export default App;
