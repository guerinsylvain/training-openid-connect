# training-openid-connect

## Pluralsight

training from pluralsight:  
https://app.pluralsight.com/library/courses/securing-aspnet-core-3-oauth2-openid-connect/table-of-contents

## Some notes

New-SelfSignedCertificate -Subject "CN=MarvinIdSrvSigningCert" -CertStoreLocation "Cert:\LocalMachine\My"

add-migration -name InitialIdentityServerConfigurationDBMigration -context ConfigurationDbContext  
add-migration -name InitialIdentityServerConfigurationDBMigration -context PersistedGrantDbContext

## SPA Considerations

Because this training is showcasing an asp.net server-side application...

### Why not Implicit Flow?

Because it exposes access_token into the browser URL and you will not have refresh_token facility because OP client is not able to call /token endpoint which requires client authentication.

Below is the implicit flow diagram which helps you to understand the whole flow.

![Implicit Flow](https://github.com/guerinsylvain/training-openid-connect/blob/main/Misc/implicit%20flow.png)

### Why not Authorization Code Flow (without PKCE) for SPA?

Don't use it. Without PKCE that means You need to store the client secret on your browser to request /token endpoint and get an access token. Store client secret at the browser is a big security risk.

This flow is generally used at the server-side. Where we can safely store client id and client secret. In this case, the /token endpoint is protected by Token Endpoint authentication methods. ✔️ You don't need PKCE flow if you are managing authentication flow using the server.

### Why to use Authorization Code PKCE flow?

Because It does not expose access token to the browser in URL and you don't need client secret at all.

PKCE stands for Proof Key for Code Exchange.

In this case, the /token endpoint is not protected by Token Endpoint authentication methods. Because of PCKE, OP Server use code_challenge and code_verifier to verify request. So you need to remove auth methods for token endpoint using your OpenID connect server admin panel.

![Authorization Code PKCE Flow](https://github.com/guerinsylvain/training-openid-connect/blob/main/Misc/authorization%20code%20PKCE%20flow.png)
