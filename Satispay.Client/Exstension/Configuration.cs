using Microsoft.Extensions.DependencyInjection;
using Satispay.Client.ClientOperation;
using Satispay.Client.Handler;
using Satispay.Client.Interface;

namespace Satispay.Client.Exstension
{
	public static class Configuration
	{
		public static ISatispayBuilder ConfigureAuthenticationSatispayClient
			(this IServiceCollection services, bool production)
		{
			services.AddHttpClient<IAuthenticationSatispayClient, AuthenticationSatispayClient>("TokenClient", client => new AuthenticationSatispayClient(production, client));

			//services.AddHttpClient("TokenClient");
			//services.AddTransient<IAuthenticationSatispayClient>(x =>
			//						 {
			//							 var factory = x.GetRequiredService<IHttpClientFactory>();
			//							 var client = factory.CreateClient("TokenClient");
			//							 return new AuthenticationSatispayClient(production, client);
			//						 }
			//);

			return new DefaultAuthenticationbuilder(services);
		}
		public static void ConfigureSatispayAPIClient(this ISatispayBuilder builder, string keyId, string privateKey, bool production)
		{

			builder.Services.AddHttpClient<ISatispayClient, SatispayClient>("SatispayClient", client => new SatispayClient(client, production))
				.AddHttpMessageHandler(x => new SecurityDelegatingHandler(keyId, privateKey));

			//builder.Services.AddHttpClient("SatispayClient").AddHttpMessageHandler(x => new SatispayRequestSigningDelegatingHandler(keyId, privateKey));

			//builder.Services.AddTransient(x =>
			//{
			//	var factory = x.GetRequiredService<IHttpClientFactory>();
			//	var client = factory.CreateClient("SatispayClient");
			//	return new SatispayClient.SatispayClient(client, production);
			//}
			//);
		}
	}
}
