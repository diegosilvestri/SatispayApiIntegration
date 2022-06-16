using Satispay.Client.Exstension;
using Satispay.Client.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Client.ClientOperation
{
	public partial class SatispayClient
	{
		/// <summary>
		/// API to get details about pre-authorized token
		/// </summary>
		/// <param name="id">Pre-Authorized Payment Token</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Task<SatispayResponse<AuthorizationResponse>> GetAuthorization(string id, CancellationToken cancellationToken = default)
		{
			return SendRequestAsync<AuthorizationResponse>(HttpMethod.Get, $"v1/pre_authorized_payment_tokens/{id}", null, null, cancellationToken);
		}

		public Task<SatispayResponse<CreateAuthorizationResponse>> CreateAuthorization(CreateAuthorizationRequest request, string IdempotencyKey = "", CancellationToken cancellationToken = default)
		{
			if (request.IsNull())
				throw new NullReferenceException("Valorizzare la request!");


			OptionalInformationWithIdempotencyKey optional = new OptionalInformationWithIdempotencyKey(IdempotencyKey);
			return SendRequestAsync<CreateAuthorizationResponse>(HttpMethod.Post, $"v1/pre_authorized_payment_tokens", request, optional.GetHeaderOptionalInformation(), cancellationToken);
		}

		public Task<SatispayResponse<UpdateAuthorizationResponse>> UpdateAuthorization(string id, UpdateAuthorizationRequest request, CancellationToken cancellationToken = default)
		{
			if (request.IsNull())
				throw new NullReferenceException("Valorizzare la request!");

			if (request.Status != Models.Enum.PaymentStatus.CANCELED)
				throw new InvalidOperationException("Status must be CANCELED");

			return SendRequestAsync<UpdateAuthorizationResponse>(HttpMethod.Put, $"v1/pre_authorized_payment_tokens/{id}", request, null, cancellationToken);
		}
	}
}
