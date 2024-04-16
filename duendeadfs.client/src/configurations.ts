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
