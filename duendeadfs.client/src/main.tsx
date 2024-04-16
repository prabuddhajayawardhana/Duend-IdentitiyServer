import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import App from './App.tsx'


// const configuration = {
//     client_id: "weatherapi",
//     redirect_uri: "http://localhost:5173/signin-oidc",
//     silent_redirect_uri:
//         window.location.origin + "/about",
//     scope: "weatherapi", // offline_access scope allow your client to retrieve the refresh_token
//     authority: "https://localhost:5001",
//     service_worker_relative_url: "/OidcServiceWorker.js", // just comment that line to disable service worker mode
//     service_worker_only: false,
//     demonstrating_proof_of_possession: false,
// };

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <App />
    </React.StrictMode>,
)
