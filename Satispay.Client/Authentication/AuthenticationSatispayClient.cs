using Satispay.Client.ClientOperation;
using Satispay.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Client.Interface
{
	internal class AuthenticationSatispayClient : SatispayClientBase, IAuthenticationSatispayClient
	{
		readonly HttpClient Client;
		public AuthenticationSatispayClient(bool production, HttpClient client)
		{
			Client = client;
			BuildAddress(production);


		}

		public AuthenticationSatispayClient(bool production)
		{
			Client = new HttpClient();
			BuildAddress(production);
		}

		void BuildAddress(bool production)
		{
			Client.BaseAddress = new System.Uri(production ? Costant.ProductionBaseUrl : Costant.StagingBaseUrl);
		}

		public async Task<SatispayResponse<KeyIdResponse>> GetKeyId(string publicKey, string token, CancellationToken cancellationToken)
		{
			var request = new KeyIdRequest() { PublicKey = publicKey, Token = token };

			var result = await Client.PostAsJsonAsync("v1/authentication_keys", request, cancellationToken);

			return await BuildResponse<KeyIdResponse>(result);
			//await Utility.ThrowErrorIfAnyAsync(result);

			//var response = await result.Content.ReadFromJsonAsync<KeyIdResponse>();
			//return response;

		}

		public void Dispose()
		{
			Client?.Dispose();
		}

	}
}
