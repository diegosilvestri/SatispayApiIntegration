using NUnit.Framework;
using Satispay.Client.ClientOperation;
using Satispay.Client.Interface;
using Satispay.Client.Models;
using Satispay.Client.Models.Enum;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Test
{
	public class SatispayTestCase
	{
		[Ignore("You can call only one time for Activation Token")]
		[TestCase]
		public async Task SatispayClient_GetKeyId()
		{

			CancellationTokenSource token = new CancellationTokenSource();
			using var service = AuthenticationClientFactory.GetAuthenticationClient(false);
			var result = await service.GetKeyId(Costant.publicKey, Costant.ActivationToken, token.Token);

			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result.Response.KeyId);// save this key id in constant cs
		}
		[Test]
		public async Task SatispayClient_GetAcceptedPaymentListProductionWithOptionalInfo()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			PaymentsListRequest request = new PaymentsListRequest();
			request.OptionalInfo = new OptionalInformation();
			request.OptionalInfo.DeviceType = DeviceType.POS;
			request.OptionalInfo.OperativeSystemName = "Windows 11Insider ";
			request.Status = PaymentStatus.ACCEPTED;
			request.Limit = 10;
			var result = await service.GetPaymentDetailsListAsync(request, token.Token);
			Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
			Assert.IsNotNull(result.Response);
		}
		[Test]
		public async Task SatispayClient_GetPendingPaymentListWithOptionalInfo()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			PaymentsListRequest request = new PaymentsListRequest();
			request.OptionalInfo = new OptionalInformation();
			request.OptionalInfo.DeviceType = DeviceType.POS;
			request.Status = PaymentStatus.PENDING;
			request.Limit = 10;
			var result = await service.GetPaymentDetailsListAsync(request, token.Token);
			Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
			Assert.IsNotNull(result.Response);
		}
		[Test]
		public async Task SatispayClient_GetCanceledPaymentListWithOptionalInfo()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			PaymentsListRequest request = new PaymentsListRequest();
			request.OptionalInfo = new OptionalInformation();
			request.OptionalInfo.DeviceType = DeviceType.POS;
			request.Status = PaymentStatus.CANCELED;
			request.Limit = 10;
			var result = await service.GetPaymentDetailsListAsync(request, token.Token);
			Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
			Assert.IsNotNull(result.Response);
		}
		[Test]
		public async Task SatispayClient_GetAcceptedPaymentListWithoutOptionalInfo()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			PaymentsListRequest request = new PaymentsListRequest();
			request.Status = PaymentStatus.ACCEPTED;
			request.Limit = 10;
			var result = await service.GetPaymentDetailsListAsync(request, token.Token);
			Assert.IsNotNull(result);
			Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
		}

		[Test]
		public async Task SatispayClient_GetCanceledPaymentListWithoutOptionalInfo()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			PaymentsListRequest request = new PaymentsListRequest();
			request.Status = PaymentStatus.CANCELED;
			request.Limit = 10;
			var result = await service.GetPaymentDetailsListAsync(request, token.Token);
			Assert.IsNotNull(result);
			Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
		}

		[Test]
		public async Task SatispayClient_NullReferenceExceptionPaymentListWithoutParameter()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			await Task.Run(() => Assert.CatchAsync<NullReferenceException>(async () => await service.GetPaymentDetailsListAsync(null, token.Token)));
		}

		[Test]
		public async Task SatispayClient_PerformsAuthentication()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);
			var authentication = await service.TestAuthenticationAsync(token.Token);
			Assert.IsNotNull(authentication);
			Assert.AreEqual(authentication.StatusCode, HttpStatusCode.OK);
			Assert.IsTrue(authentication.Response.Signature.Valid);
			Assert.IsNotNull(authentication.Response.AuthenticationKey.Role);
			Assert.AreNotEqual(authentication.Response.AuthenticationKey.Role, "PUBLIC");
		}
		[Test]
		public async Task Satispay_GetDailyClosure()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, true);
			var response = await service.GetShopDailyClosureAsync(DateTime.Now, token.Token);
		}
	}
}