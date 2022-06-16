using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class UpdateAuthorizationResponse : AuthorizationResponseBase
	{
		/// <summary>
		/// Unique ID of the consumer
		/// </summary>
		[JsonPropertyName("consumer_uid")]
		public string ConsumerUid { get; set; }
	}
}
