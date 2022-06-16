using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class PaymentDetailsListResponse
	{
		/// <summary>
		/// Are there more items in the list?
		/// </summary>
		[JsonPropertyName("has_more")]
		public bool HasMore { get; set; }
		/// <summary>
		/// Payment List
		/// </summary>
		[JsonPropertyName("data")]
		public List<PaymentDetailsResponse> PaymentDetails { get; set; }
	}
}
