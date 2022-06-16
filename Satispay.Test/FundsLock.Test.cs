using Satispay.Client.ClientOperation;
using Satispay.Client.Models;
using Satispay.Client.Models.Enum;
using NUnit.Framework;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Test
{
	public class FundsLock
	{
		[Test]
		public async Task Satispay_CreateFundsLockPayment()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			CreateFundLockPaymentRequest request = new CreateFundLockPaymentRequest(99, Currency.EUR);

			var result = await service.CreateFundLockPaymentAsync(request, null, token.Token);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);


		}

		[Test]
		public async Task Satispay_GetPaymentsList()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);
			PaymentsListRequest request = new PaymentsListRequest(PaymentStatus.PENDING);
			var result = await service.GetPaymentDetailsListAsync(request, token.Token);
			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
		}

		[Test]
		public async Task Satispay_CreateCancelFundsLockPayment()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			CreateFundLockPaymentRequest request = new CreateFundLockPaymentRequest(99, Currency.EUR);

			var result = await service.CreateFundLockPaymentAsync(request, null, token.Token);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

			var payment = await service.GetPaymentDetailsAsync(result.Response.Id);

			Assert.AreEqual(HttpStatusCode.OK, payment.StatusCode);
			CancelPaymentRequest cancelRequest = new CancelPaymentRequest(99);

			var response = await service.CancelPaymentAsync(result.Response.Id, cancelRequest, null, token.Token);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);


		}
	}
}
