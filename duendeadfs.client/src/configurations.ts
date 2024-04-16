import { TokenRenewMode, TokenAutomaticRenewMode } from '@axa-fr/react-oidc';

export const configurationIdentityServer = {
    client_id: "interactive.public.short",
    redirect_uri: "https://localhost:7001/signin-oidc",
    silent_redirect_uri: window.location.origin + "/authentication/silent-callback",
    //silent_login_uri: window.location.origin + '/signin-oidc',
    scope: "weatherapi",
    authority: 'https://localhost:5001',
    // authority_time_cache_wellknowurl_in_second: 60* 60,
    refresh_time_before_tokens_expiration_in_second: 40,
    service_worker_relative_url: '/OidcServiceWorker.js',
    service_worker_only: false,
    // storage: localStorage,
    // silent_login_timeout: 3333000
    // monitor_session: true,
    extras: { youhou_demo: 'youhou' },
    token_renew_mode: TokenRenewMode.access_token_invalid,
    token_automatic_renew_mode: TokenAutomaticRenewMode.AutomaticOnlyWhenFetchExecuted,
    demonstrating_proof_of_possession: false
};

// export const configurationIdentityServer1 = {
//     client_id: 'balosar-blazo',
//     redirect_uri: window.location.origin + '/authentication/callback',
//     silent_redirect_uri: window.location.origin + '/authentication/silent-callback',
//     // silent_login_uri: window.location.origin + '/authentication/silent-login',
//     scope: 'openid offline_access profile email',
//     authority: 'https://localhost:44310',
//     // authority_time_cache_wellknowurl_in_second: 60* 60,
//     refresh_time_before_tokens_expiration_in_second: 40,
//     // service_worker_relative_url: '/OidcServiceWorker.js',
//     service_worker_only: false,
//     // storage: localStorage,
//     // silent_login_timeout: 3333000
//     // monitor_session: true,
//     token_renew_mode: TokenRenewMode.access_token_invalid,
// };

// export const configurationIdentityServerWithHash = {
//     client_id: 'weatherapi',
//     redirect_uri: window.location.origin + '/multi-auth/authentification#authentication-callback',
//     silent_redirect_uri: window.location.origin + '/multi-auth/authentification#authentication-silent-callback',
//     silent_login_uri: window.location.origin + '/multi-auth/authentification#authentication-silent-login',
//     scope: 'openid profile email api offline_access',
//     authority: 'https://localhost:5001',
//     refresh_time_before_tokens_expiration_in_second: 10,
//     service_worker_relative_url: '/OidcServiceWorker.js',
//     service_worker_only: false,
// };

// export const configurationIdentityServerWithoutDiscovery = {
//     client_id: 'weatherapi',
//     redirect_uri: window.location.origin + '/authentication/callback',
//     silent_redirect_uri: window.location.origin + '/authentication/silent-callback',
//     scope: 'openid profile email api offline_access',
//     authority: 'https://localhost:5001',
//     authority_configuration: {
//         authorization_endpoint: 'https://localhost:5001/connect/authorize',
//         token_endpoint: 'https://localhost:5001/connect/token',
//         userinfo_endpoint: 'https://localhost:5001/connect/userinfo',
//         end_session_endpoint: 'https://localhost:5001/connect/endsession',
//         revocation_endpoint: 'https://localhost:5001/connect/revocation',
//         check_session_iframe: 'https://localhost:5001/connect/checksession',
//     },
//     refresh_time_before_tokens_expiration_in_second: 10,
//     service_worker_relative_url: '/OidcServiceWorker.js',
//     service_worker_only: false,
// };

// export const configurationAuth0 = {
//     client_id: 'xGZxEAJhzlkuQUlWl90y1ntIX-0UDWHx',
//     redirect_uri: window.location.origin + '/callback',
//     scope: 'openid profile email api offline_access',
//     authority: 'https://kdhttps.auth0.com',
//     refresh_time_before_tokens_expiration_in_second: 10,
//     service_worker_relative_url: '/OidcServiceWorker.js',
//     service_worker_only: false,
// };

// export const configurationGoogle = {
//     client_id: '908893276222-f2drloh56ll0g99md38lv2k810d0nk0p.apps.googleusercontent.com',
//     redirect_uri: `${window.location.origin}/multi-auth/callback-google`,
//     silent_redirect_uri: window.location.origin + '/multi-auth/silent-callback-google',
//     scope: 'openid profile email',
//     authority: 'https://accounts.google.com/',
//     service_worker_relative_url: '/OidcServiceWorker.js',
//     service_worker_only: false,
//     token_request_extras: {
//         client_secret: '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',
//     },
//     monitor_session: false,
// };
