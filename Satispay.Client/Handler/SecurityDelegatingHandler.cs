using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Client.Handler
{
	public class SecurityDelegatingHandler : DelegatingHandler
	{
		private readonly string keyId;
		private readonly string privateKey;


		public SecurityDelegatingHandler()
		{

		}
		public SecurityDelegatingHandler(
			string keyId,
			string privateKey,
			HttpMessageHandler innerHandler) : base(innerHandler)
		{
			this.keyId = keyId;
			this.privateKey = privateKey;
		}

		public SecurityDelegatingHandler(
			string keyId,
			string privateKey,
			bool createInnerHandler = false)
		{
			this.keyId = keyId;
			this.privateKey = privateKey;

			if (createInnerHandler)
				InnerHandler = new HttpClientHandler();
		}

		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			var now = DateTime.Now;
			//var date = now.ToString("ddd, d MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture) + " " + now.ToString("zzz").Replace(":", string.Empty);
			var date = $"{now.ToString("ddd, d MMM yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture)}";
			request.Headers.Add("Date", date);
			request.Headers.Add("Host", Utility.Encoder.Encode(request.RequestUri.Host));

			await AddDigestHeaderAsync(request);

			AddAuthorizationHeader(request);

			return await base.SendAsync(request, cancellationToken);
		}

		private static async Task AddDigestHeaderAsync(HttpRequestMessage request)
		{

			var body = request.Content != null
				? await request.Content.ReadAsStringAsync()
				: string.Empty;


			using var sha256 = SHA256.Create();
			var hashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(body));

			var base64 = Convert.ToBase64String(hashed);
			request.Headers.Add("Digest", $"SHA-256={base64}");
		}

		private void AddAuthorizationHeader(HttpRequestMessage request)
		{
			var @string = BuildStringToSign(request);
			var signature = SignData(@string);
			var sign = Convert.ToBase64String(signature);

			var header = $"keyId=\"{keyId}\", algorithm=\"rsa-sha256\", headers=\"(request-target) host date digest\", signature=\"{sign}\"";
			request.Headers.Authorization = new AuthenticationHeaderValue("Signature", header);
		}

		private byte[] SignData(string data)
		{
			using var rsa = RSA.Create();
			rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
			return rsa.SignData(Encoding.UTF8.GetBytes(data), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
		}

		private static string BuildStringToSign(HttpRequestMessage request)
			=> new StringBuilder()
				.Append($"(request-target): {request.Method.ToString().ToLowerInvariant()} {request.RequestUri.PathAndQuery}")
				.Append("\n")
				.Append($"host: {request.RequestUri.Host}")
				.Append("\n")
				.Append($"date: {request.Headers.GetValues("Date").Single()}")
				.Append("\n")
				.Append($"digest: {request.Headers.GetValues("Digest").Single()}")
				.ToString();
	}
}
