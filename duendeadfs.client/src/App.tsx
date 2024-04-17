import { RouterProvider, createBrowserRouter } from "react-router-dom";
import Home from "./components/Home";
import About from "./components/layout/About";
import Signin from "./components/layout/Signin";
import Profile from "./components/layout/Profile";
import { AuthProvider } from "oidc-react";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
    children: [
      {
        path: "",
        element: <Profile />,
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
  redirectUri: "http://localhost:5173"
};


function App() {

  return (
    <AuthProvider {...oidcConfig} >
      <RouterProvider router={router} />
    </AuthProvider>
  );
}

export default App;
