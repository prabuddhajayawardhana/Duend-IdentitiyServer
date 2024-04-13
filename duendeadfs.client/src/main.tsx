import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import Home from './components/Home.tsx'
import { AuthProvider } from 'react-oidc-context'

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
  },
  {
    path: "/whether",
    element: <App />,
  }
]);

const oidcConfig = {
  authority: "https://localhost:5002",
  client_id: "weatherapi",
  redirect_uri: "https://localhost:7001",
  response_type: 'code',
  scope: 'weatherapi'
};

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
     <AuthProvider {...oidcConfig}>
      <RouterProvider router={router} />
    </AuthProvider>
  </React.StrictMode>,
)
