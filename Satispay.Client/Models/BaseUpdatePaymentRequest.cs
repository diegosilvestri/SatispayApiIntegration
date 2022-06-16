using Satispay.Client.Models.Enum;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public abstract class BaseUpdatePaymentRequest
	{
		[JsonPropertyName("action")]
		public PaymentAction Action { get; }
		[JsonPropertyName("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonPropertyName("amount_unit")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public int? AmountUnit { get; set; }


		public BaseUpdatePaymentRequest(PaymentAction paymentAction, int? amountUnit)
		{
			Action = paymentAction;
			AmountUnit = amountUnit;
		}
	}
}
