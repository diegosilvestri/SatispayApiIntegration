using Satispay.Client.Exstension;
using Satispay.Client.Handler;
using Satispay.Client.Interface;
using Satispay.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Client.ClientOperation
{
	public partial class SatispayClient : SatispayClientBase, ISatispayClient
	{
		private readonly HttpClient _httpClient;

		public SatispayClient(
			string keyId,
			string privateKey,
			bool production)
		{
			_httpClient = BuildClient(keyId, privateKey, production);
		}
		/// <summary>
		/// Usato in .NetCore
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="production"></param>
		public SatispayClient(
			HttpClient httpClient,
			bool production)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = BuildUri(production);
		}

		public Task<SatispayResponse<AuthenticationTestResponse>> TestAuthenticationAsync(
		CancellationToken cancellationToken = default)
		{
			CreateMatchCodePaymentRequest payment = new CreateMatchCodePaymentRequest(100, Client.Models.Enum.Currency.EUR);

			//if (payment.Metadata.IsNull())
			//	payment.Metadata = new System.Collections.Generic.Dictionary<string, string>();

			//payment.Metadata.Add(CGIL.Satispay.Client.Costant.PhoneNumberMetaData, "00393428088442");
			//OptionalInformationWithIdempotencyKey optional = new OptionalInformationWithIdempotencyKey(Guid.NewGuid().ToString());

			return SendRequestAsync<AuthenticationTestResponse>(
				 HttpMethod.Post, "/wally-services/protocol/tests/signature", payment, null, cancellationToken);
		}

		private HttpClient BuildClient(
			string keyId,
			string privateKey,
			bool production)
		{
			var requestSigningHandler = new SecurityDelegatingHandler(keyId, privateKey, true);

			return new HttpClient(requestSigningHandler)
			{
				BaseAddress = BuildUri(production)
			};
		}

		private Uri BuildUri(bool production)
			=> new Uri(production ? Costant.ProductionBaseUrl : Costant.StagingBaseUrl);

		private async Task<SatispayResponse<T>> SendRequestAsync<T>(
			HttpMethod httpMethod,
			string requestUri,
			object requestBody,
			Dictionary<string, string> optionalHeaderInfo,
			CancellationToken cancellationToken) where T : class
		{
			var request = new HttpRequestMessage(httpMethod, requestUri);

			if (requestBody != null)
				request.Content = requestBody.ToJsonContent();

			if (optionalHeaderInfo.IsNotNull())
				foreach (var item in optionalHeaderInfo)
				{
					request.Headers.Add(item.Key, item.Value);
				}

			var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);


			return await BuildResponse<T>(response);

		}




		public void Dispose() => _httpClient?.Dispose();
	}


}
