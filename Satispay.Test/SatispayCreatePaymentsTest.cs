using NUnit.Framework;
using Satispay.Client.ClientOperation;
using Satispay.Client.Exstension;
using Satispay.Client.Models;
using Satispay.Client.Models.Enum;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Test
{
	public class SatispayCreatePaymentsTest
	{
		[Test]
		[TestCase("+39342xxxxxxx")]
		public async Task Satispay_CreateMatchCodePayment(string phonNumber)
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);
			CreateMatchCodePaymentRequest payment = new CreateMatchCodePaymentRequest(100, Client.Models.Enum.Currency.EUR);

			if (payment.Metadata.IsNull())
				payment.Metadata = new System.Collections.Generic.Dictionary<string, string>();

			payment.Metadata.Add(Client.Costant.PhoneNumberMetaData, phonNumber);

			OptionalInformationWithIdempotencyKey optional = new OptionalInformationWithIdempotencyKey(Guid.NewGuid().ToString());

			var result = await service.CreateMatchCodePaymentAsync(payment, optional, token.Token);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);


		}

		[Test]
		[TestCase("+39342xxxxxxx")]
		public async Task Satispay_CreateMatchUserPayment(string phonNumber)
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			var consumerResponse = await service.GetConsumerAsync(phonNumber, token.Token);
			if (consumerResponse.IsNotNull() && consumerResponse.StatusCode == HttpStatusCode.OK)
			{
				CreateMatchUserPaymentRequest payment = new CreateMatchUserPaymentRequest(consumerResponse.Response.ConsumerId, 100, Currency.EUR);

				if (payment.Metadata.IsNull())
					payment.Metadata = new System.Collections.Generic.Dictionary<string, string>();

				payment.Metadata.Add(Client.Costant.PhoneNumberMetaData, phonNumber);



				OptionalInformationWithIdempotencyKey optional = new OptionalInformationWithIdempotencyKey(Guid.NewGuid().ToString());

				var result = await service.CreateMatchUserPaymentAsync(payment, optional, token.Token);
				Assert.IsNotNull(result);
				Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
			}
		}

		[Test]
		public async Task Satispay_RefundPayment()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			PaymentsListRequest request = new PaymentsListRequest();
			request.Status = PaymentStatus.ACCEPTED;
			request.Limit = 10;
			var result = await service.GetPaymentDetailsListAsync(request, token.Token);
			var payment = result.Response.PaymentDetails.FirstOrDefault();


			if (payment.IsNotNull())
			{

				var requestRefund = new CancelOrRefundPaymentRequest();

				var resultRefund = await service.CancelOrRefundPaymentAsync(payment.Id, requestRefund, null, token.Token);

				Assert.AreEqual(HttpStatusCode.OK, resultRefund.StatusCode);
			}

		}

		[Test]
		public async Task Satispay_CreatePre_Authorization()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);


			CreateAuthorizationRequest request = new CreateAuthorizationRequest();
			request.Reason = "Test Creazione Authorization Request";

			var response = await service.CreateAuthorization(request, Guid.NewGuid().ToString(), token.Token);

			Assert.IsNotNull(response);
			Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

		}

		[Test]
		[TestCase("fc4927dc-0115-4c2b-8c9e-71c8bf225ea9")]
		[TestCase("5571745a-b942-4387-99a4-5d9426f72e86")]
		public async Task Satispay_GetPre_Authorization(string guid)
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			var response = await service.GetAuthorization(guid, token.Token);

			Assert.IsNotNull(response);
			Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
		}

		[Test]
		[TestCase("5571745a-b942-4387-99a4-5d9426f72e86")]
		public async Task Satispay_UpdatePre_Authorization(string guid)
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			var request = new UpdateAuthorizationRequest();
			var response = await service.UpdateAuthorization(guid, request, token.Token);

			Assert.IsNotNull(response);
			Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
		}


	}
}
