# SatispayApiIntegration 
Satispay Api Intergation
Net Standard 2.1 Library


I'm started and integrate SatispayDotNet project

You can register it with extension method 
service.ConfigureAuthenticationSatispayClient(production).ConfigureSatispayAPIClient(keyId,privateKey,production)
or with Factory

var authenticationClient = AuthenticationClientFactory.GetAuthenticationClient(production)
var apiClient = SatispayClientFactory.GetClient(keyId,privateKey,production)

To create private key read Satispay site https://developers.satispay.com/reference/generate-rsa-keys

You can test Authentication with TestAuthenticationAsync method.

