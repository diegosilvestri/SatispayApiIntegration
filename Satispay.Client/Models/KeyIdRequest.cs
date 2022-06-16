using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class KeyIdRequest
	{
		[JsonPropertyName("public_key")]
		public string PublicKey { get; set; }

		[JsonPropertyName("token")]
		public string Token { get; set; }
	}
}
