using Satispay.Client.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Client.Interface
{
	public interface ISatispayClient : IDisposable
	{
		Task<SatispayResponse<AuthenticationTestResponse>> TestAuthenticationAsync(CancellationToken cancellationToken = default);
		/// <summary>
		/// API to retrieve the list of payments for a specific shop. The shop is automatically filtered based on the KeyID used in the authorisation header.
		/// </summary>
		/// <param name="request">Payments request</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<PaymentDetailsListResponse>> GetPaymentDetailsListAsync(PaymentsListRequest request, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to retrieve the detail of a specific payment
		/// </summary>
		/// <param name="paymentId"></param>
		/// <param name="responseWaitTime"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<PaymentDetailsResponse>> GetPaymentDetailsAsync(string paymentId, int responseWaitTime = 5, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to update the state or metadata of a payment
		/// </summary>
		/// <param name="paymentId">Paymant Id</param>
		/// <param name="request"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<PaymentDetailsResponse>> AcceptPaymentAsync(string paymentId, AcceptPaymentRequest request, OptionalInformation optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to update the state or metadata of a payment
		/// </summary>
		/// <param name="paymentId">Paymant Id</param>
		/// <param name="request"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<PaymentDetailsResponse>> CancelPaymentAsync(string paymentId, CancelPaymentRequest request, OptionalInformation optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to update the state or metadata of a payment
		/// </summary>
		/// <param name="paymentId">Paymant Id</param>
		/// <param name="request"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<PaymentDetailsResponse>> CancelOrRefundPaymentAsync(string paymentId, CancelOrRefundPaymentRequest request, OptionalInformation optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to create a Refund payment
		/// </summary>
		/// <param name="preAuthorizedFundLockPaymentRequest"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken">Token di cancellazione</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		Task<SatispayResponse<CreatePaymentsResponse>> CreateRefundPaymentAsync(CreateRefundPaymentRequest refundRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to create a MatchCode payment
		/// </summary>
		/// <param name="preAuthorizedFundLockPaymentRequest"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken">Token di cancellazione</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		Task<SatispayResponse<CreatePaymentsResponse>> CreateMatchCodePaymentAsync(CreateMatchCodePaymentRequest matchCodeRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to create a MatchUser payment
		/// </summary>
		/// <param name="preAuthorizedFundLockPaymentRequest"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken">Token di cancellazione</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		Task<SatispayResponse<CreatePaymentsResponse>> CreateMatchUserPaymentAsync(CreateMatchUserPaymentRequest matchCodeRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to create a PreAuthorized payment
		/// </summary>
		/// <param name="preAuthorizedFundLockPaymentRequest"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken">Token di cancellazione</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		Task<SatispayResponse<CreatePaymentsResponse>> CreatePreAuthorizedPaymentAsync(CreatePreAuthorizedPaymentRequest preAuthorizedPaymentRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to create a FundLock payment
		/// </summary>
		/// <param name="preAuthorizedFundLockPaymentRequest"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken">Token di cancellazione</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		Task<SatispayResponse<CreatePaymentsResponse>> CreateFundLockPaymentAsync(CreateFundLockPaymentRequest fundLockPaymentRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to create a preAuthorizedFundLock payment
		/// </summary>
		/// <param name="preAuthorizedFundLockPaymentRequest"></param>
		/// <param name="optionalHeaderInformation">Informazioni Opzionali Utile valorizzare il campo idempotencyKey</param>
		/// <param name="cancellationToken">Token di cancellazione</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		Task<SatispayResponse<CreatePaymentsResponse>> CreatePreAuthorizedFundLockPaymentAsync(CreatePreAuthorizedFundLockPaymentRequest preAuthorizedFundLockPaymentRequest, OptionalInformationWithIdempotencyKey optionalHeaderInformation, CancellationToken cancellationToken = default);
		/// <summary>
		///API to retrieve shop daily closure
		/// </summary>
		/// <param name="dailyClosure">The day on which retrieve the daily closure (format yyyyMMdd)</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<ShopDailyClosureResponse>> GetShopDailyClosureAsync(DateTime dailyClosure, CancellationToken cancellationToken = default);
		/// <summary>
		/// Api to Retrive Customer Id
		/// </summary>
		/// <param name="phoneNumber">Phone Number</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<Consumer>> GetConsumerAsync(string phoneNumber, CancellationToken cancellationToken = default);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<AuthorizationResponse>> GetAuthorization(string id, CancellationToken cancellationToken = default);
		/// <summary>
		/// API to request a new pre-authorized token
		/// </summary>
		/// <param name="request"></param>
		/// <param name="IdempotencyKey"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<CreateAuthorizationResponse>> CreateAuthorization(CreateAuthorizationRequest request, string IdempotencyKey = "", CancellationToken cancellationToken = default);
		/// <summary>
		/// API to cancel/revoke a pre-authorized token or to associate an existing pre-authorized token in PENDING state with a consumer
		/// </summary>
		/// <param name="id">Pre-Authorized Payment Token</param>
		/// <param name="request">Request data</param>
		/// <param name="IdempotencyKey"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<UpdateAuthorizationResponse>> UpdateAuthorization(string id, UpdateAuthorizationRequest request, CancellationToken cancellationToken = default);

		/// <summary>
		/// API to create a PEM certificate and the private key for a shop mqtt device.
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<MqttCertificateResponse>> CreateMqttCertificate(CancellationToken cancellationToken = default);

		/// <summary>
		/// API to open a session from a fund lock
		/// </summary>
		/// <param name="request"></param>
		/// <param name="IdempotencyKey"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<SatispayResponse<OpenSessionResponse>> OpenSession(OpenSessionRequest request, string IdempotencyKey = "", CancellationToken cancellationToken = default);

	}
}