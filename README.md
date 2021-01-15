# training-openid-connect

## pluralsight

training from pluralsight:
https://app.pluralsight.com/library/courses/securing-aspnet-core-3-oauth2-openid-connect/table-of-contents

## some notes

New-SelfSignedCertificate -Subject "CN=MarvinIdSrvSigningCert" -CertStoreLocation "Cert:\LocalMachine\My"

add-migration -name InitialIdentityServerConfigurationDBMigration -context ConfigurationDbContext  
add-migration -name InitialIdentityServerConfigurationDBMigration -context PersistedGrantDbContext

## spa

### why not implicit flow?

Because it exposes access_token into the browser URL and you will not have refresh_token facility because OP client is not able to call /token endpoint which requires client authentication.

Below is the implicit flow diagram which helps you to understand the whole flow.

![Implicit Flow](https://github.com/guerinsylvain/training-openid-connect/blob/main/Misc/implicit%20flow.png)
