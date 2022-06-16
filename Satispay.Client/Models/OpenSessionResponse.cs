using Satispay.Client.Models.Enum;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class OpenSessionResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("amount_unit")]
		public int AmountUnit { get; set; }
		[JsonPropertyName("residual_amount_unit")]
		public int ResidualAmountUnit { get; set; }
		[JsonPropertyName("currency")]
		public Currency Currency { get; set; }
		[JsonPropertyName("status")]
		public string Status { get; set; }
		[JsonPropertyName("payment_type")]
		public string PaymentType { get; set; }
	}
}
