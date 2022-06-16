using Satispay.Client.Models.Enum;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public abstract class AuthorizationResponseBase
	{
		/// <summary>
		/// Unique ID of the authorization token
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; }
		/// <summary>
		/// Generated code identifier
		/// </summary>
		[JsonPropertyName("code_identifier")]
		public string CodeIdentifier { get; set; }
		/// <summary>
		/// Unique ID of the shop
		/// </summary>
		[JsonPropertyName("shop_uid")]
		public string ShopUid { get; set; }
		/// <summary>
		/// Status of the authorization token (PENDING, ACCEPTED or CANCELED)
		/// </summary>
		[JsonPropertyName("status")]
		public PaymentStatus Status { get; set; }
		/// <summary>
		/// The reason why the token has been required
		/// </summary>
		[JsonPropertyName("reason")]
		public string Reason { get; set; }
		/// <summary>
		/// The url to be notified in case of change
		/// </summary>
		[JsonPropertyName("callback_url")]
		public string CallbackUrl { get; set; }
		/// <summary>
		/// Metadata inserted within the authorization request
		/// </summary>
		[JsonPropertyName("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}

}
