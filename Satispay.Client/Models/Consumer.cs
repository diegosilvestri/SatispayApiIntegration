using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class Consumer
	{
		[JsonPropertyName("id")]
		public string ConsumerId { get; set; }
	}
}
