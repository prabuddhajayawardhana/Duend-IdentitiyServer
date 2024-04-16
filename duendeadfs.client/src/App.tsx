import { OidcProvider } from "@axa-fr/react-oidc";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import { configurationIdentityServer } from "./configurations";
import Home from "./components/Home";
import About from "./components/layout/About";
import Signin from "./components/layout/Signin";
import { SecureProfile } from "./components/layout/Profile";


const router = createBrowserRouter([
    {
      path: "/",
      element: <Home />,
      children: [
        {
          path: "/profile",
          element: <SecureProfile />
        },
        {
          path: "/about",
          element: <About />
        },
        {
          path: "/sign-in",
          element: <Signin />
        }
      ]
    },
  ]);

function App() {
  return (
    <OidcProvider configuration={configurationIdentityServer}>
        <RouterProvider router={router} />
    </OidcProvider>
  )
}

export default App