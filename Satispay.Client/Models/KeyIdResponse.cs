using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class KeyIdResponse
	{
		[JsonPropertyName("key_id")]
		public string KeyId { get; set; }
	}
}
