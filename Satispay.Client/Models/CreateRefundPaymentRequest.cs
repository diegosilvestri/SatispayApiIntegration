using Satispay.Client.Models.Enum;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class CreateRefundPaymentRequest : CreatePaymentBase
	{
		public CreateRefundPaymentRequest(int amountUnit, Currency currency) : base(PaymentFlow.REFUND, amountUnit, currency)
		{
		}
		/// <summary>
		/// Unique ID of the payment to refund (required with the REFUND flow only)
		/// </summary>
		[JsonPropertyName("parent_payment_uid")]
		public string ParentPaymentUid { get; set; } = string.Empty;


	}
}
