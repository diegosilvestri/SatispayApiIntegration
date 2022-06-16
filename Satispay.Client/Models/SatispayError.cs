using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class SatispayError
	{
		/// <summary>
		/// Error code
		/// </summary>
		[JsonPropertyName("code")]
		public int Code { get; set; }
		/// <summary>
		/// Error message
		/// </summary>
		[JsonPropertyName("Message")]
		public string Message { get; set; }
		[JsonPropertyName("Wlt")]
		public string Wlt { get; set; }

	}
}
