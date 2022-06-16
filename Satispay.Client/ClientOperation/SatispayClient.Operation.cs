using Satispay.Client.Exstension;
using Satispay.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Client.ClientOperation
{
	public partial class SatispayClient
	{
		public Task<SatispayResponse<PaymentDetailsListResponse>> GetPaymentDetailsListAsync(PaymentsListRequest request, CancellationToken cancellationToken = default)
		{

			if (request == null)
				throw new NullReferenceException("Parametri in ingressso non specificati");
			return SendRequestAsync<PaymentDetailsListResponse>(HttpMethod.Get, $"v1/payments{request.GetQueryString()}", null, request.OptionalInfo?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<PaymentDetailsResponse>> GetPaymentDetailsAsync(string paymentId, int responseWaitTime = 5, CancellationToken cancellationToken = default)
		{
			if (responseWaitTime > 60 || responseWaitTime < 0)
				throw new ArgumentOutOfRangeException($"Il valore di responseWaiteTime deve essere compreso tra 1 e 60");

			Dictionary<string, string> timeOut = new Dictionary<string, string>() { { "x-satispay-response-wait-time", responseWaitTime.ToString() } };

			return SendRequestAsync<PaymentDetailsResponse>(HttpMethod.Get, $"v1/payments/{paymentId}", null, timeOut, cancellationToken);
		}
		public Task<SatispayResponse<PaymentDetailsResponse>> AcceptPaymentAsync(string paymentId, AcceptPaymentRequest request, OptionalInformation optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrEmpty(paymentId))
				throw new ArgumentException("Id del Pagamento no valorizzato!");

			if (request.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");

			return SendRequestAsync<PaymentDetailsResponse>(HttpMethod.Put, $"v1/payments/{paymentId}", request, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<PaymentDetailsResponse>> CancelPaymentAsync(string paymentId, CancelPaymentRequest request, OptionalInformation optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrEmpty(paymentId))
				throw new ArgumentException("Id del Pagamento no valorizzato!");

			if (request.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");

			return SendRequestAsync<PaymentDetailsResponse>(HttpMethod.Put, $"v1/payments/{paymentId}", request, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<PaymentDetailsResponse>> CancelOrRefundPaymentAsync(string paymentId, CancelOrRefundPaymentRequest request, OptionalInformation optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrEmpty(paymentId))
				throw new ArgumentException("Id del Pagamento no valorizzato!");

			if (request.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");

			return SendRequestAsync<PaymentDetailsResponse>(HttpMethod.Put, $"v1/payments/{paymentId}", request, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<CreatePaymentsResponse>> CreateRefundPaymentAsync(CreateRefundPaymentRequest refundRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (refundRequest.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");
			if (string.IsNullOrEmpty(refundRequest.ParentPaymentUid))
				throw new ArgumentException($"il parametro ParentPaymentUid deve essere valorizzato!");

			return SendRequestAsync<CreatePaymentsResponse>(HttpMethod.Post, $"v1/payments", refundRequest, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);

		}
		public Task<SatispayResponse<CreatePaymentsResponse>> CreateMatchCodePaymentAsync(CreateMatchCodePaymentRequest matchCodeRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (matchCodeRequest.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");

			return SendRequestAsync<CreatePaymentsResponse>(HttpMethod.Post, $"v1/payments", matchCodeRequest, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);

		}
		public Task<SatispayResponse<CreatePaymentsResponse>> CreateMatchUserPaymentAsync(CreateMatchUserPaymentRequest matchUserRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (matchUserRequest.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");

			if (string.IsNullOrEmpty(matchUserRequest.ConsumerId))
				throw new ArgumentException($"il parametro ConsumerId deve essere valorizzato!");

			return SendRequestAsync<CreatePaymentsResponse>(HttpMethod.Post, $"v1/payments", matchUserRequest, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<CreatePaymentsResponse>> CreatePreAuthorizedPaymentAsync(CreatePreAuthorizedPaymentRequest preAuthorizedPaymentRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (preAuthorizedPaymentRequest.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");

			if (string.IsNullOrEmpty(preAuthorizedPaymentRequest.PreAuthorizedPaymentsToken))
				throw new ArgumentException($"il parametro PreAuthorizedPaymentsToken deve essere valorizzato!");

			return SendRequestAsync<CreatePaymentsResponse>(HttpMethod.Post, $"v1/payments", preAuthorizedPaymentRequest, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<CreatePaymentsResponse>> CreateFundLockPaymentAsync(CreateFundLockPaymentRequest fundLockPaymentRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (fundLockPaymentRequest.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");
			return SendRequestAsync<CreatePaymentsResponse>(HttpMethod.Post, $"v1/payments", fundLockPaymentRequest, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<CreatePaymentsResponse>> CreatePreAuthorizedFundLockPaymentAsync(CreatePreAuthorizedFundLockPaymentRequest preAuthorizedFundLockPaymentRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default)
		{
			if (preAuthorizedFundLockPaymentRequest.IsNull())
				throw new NullReferenceException("I parametri delle Request devono essere valorizzati!");
			return SendRequestAsync<CreatePaymentsResponse>(HttpMethod.Post, $"v1/payments", preAuthorizedFundLockPaymentRequest, optionalHeaderInformation?.GetHeaderOptionalInformation(), cancellationToken);
		}
		public Task<SatispayResponse<ShopDailyClosureResponse>> GetShopDailyClosureAsync(DateTime dailyClosure, CancellationToken cancellationToken = default)
		{
			var day = dailyClosure.ToString("yyyyMMdd");
			return SendRequestAsync<ShopDailyClosureResponse>(HttpMethod.Get, $"v1/daily_closure/{day}", null, null, cancellationToken);
		}

		public Task<SatispayResponse<Consumer>> GetConsumerAsync(string phoneNumber, CancellationToken cancellationToken = default)
		{
			return SendRequestAsync<Consumer>(HttpMethod.Get, $"v1/consumers/{phoneNumber}", null, null, cancellationToken);
		}

		public Task<SatispayResponse<MqttCertificateResponse>> CreateMqttCertificate(CancellationToken cancellationToken = default)
		{
			return SendRequestAsync<MqttCertificateResponse>(HttpMethod.Post, $"v1/mqtt_certificates", null, null, cancellationToken);
		}

		public Task<SatispayResponse<OpenSessionResponse>> OpenSession(OpenSessionRequest request, string IdempotencyKey = "", CancellationToken cancellationToken = default)
		{
			OptionalInformationWithIdempotencyKey optional = new OptionalInformationWithIdempotencyKey(IdempotencyKey);
			return SendRequestAsync<OpenSessionResponse>(HttpMethod.Post, $"v1/sessions", request, optional.GetHeaderOptionalInformation(), cancellationToken);
		}


	}
}
