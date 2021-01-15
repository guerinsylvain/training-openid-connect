# training-openid-connect

training from pluralsight:
https://app.pluralsight.com/library/courses/securing-aspnet-core-3-oauth2-openid-connect/table-of-contents

New-SelfSignedCertificate -Subject "CN=MarvinIdSrvSigningCert" -CertStoreLocation "Cert:\LocalMachine\My"

add-migration -name InitialIdentityServerConfigurationDBMigration -context ConfigurationDbContext
add-migration -name InitialIdentityServerConfigurationDBMigration -context PersistedGrantDbContext
