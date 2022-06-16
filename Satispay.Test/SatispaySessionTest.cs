using Satispay.Client.ClientOperation;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Test
{
	public class SatispaySessionTest
	{

		[Test]
		public async Task Satispay_CreateMqttCertificate()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			var result = await service.CreateMqttCertificate(token.Token);
			Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
			Assert.IsNotNull(result.Response);
		}
		[Ignore("Caso non gestito")]
		[Test]
		public async Task Satispay_OpenSession()
		{
			CancellationTokenSource token = new CancellationTokenSource();
			using var service = SatispayClientFactory.GetClient(Costant.KeyId, Costant.PrivateKey, false);

			var result = await service.OpenSession(new Client.Models.OpenSessionRequest("b0d978f5-b1be-434b-8ee2-ff1a362b10ff"), Guid.NewGuid().ToString(), token.Token);
			Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
			Assert.IsNotNull(result.Response);
		}
	}
}
