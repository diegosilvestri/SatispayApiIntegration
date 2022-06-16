using Satispay.Client.Models.Enum;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class UpdateAuthorizationRequest
	{
		public UpdateAuthorizationRequest(string consumerId = "")
		{ }
		/// <summary>
		/// The update status to perform (CANCELED).
		/// </summary>
		[JsonPropertyName("status")]
		public PaymentStatus Status { get; } = PaymentStatus.CANCELED;
		/// <summary>
		/// Unique ID of the consumer used to bind the token.
		/// </summary>
		[JsonPropertyName("consumer_uid")]
		public string ConsumerId { get; set; }
		/// <summary>
		/// Generic field that can be used to store additional data.
		/// </summary>
		[JsonPropertyName("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

	}
}
