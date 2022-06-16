using Satispay.Client.Models.Enum;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class CreateMatchUserPaymentRequest : CreatePaymentBase
	{
		public CreateMatchUserPaymentRequest(string consumerId, int amountUnit, Currency currency) : base(PaymentFlow.MATCH_USER, amountUnit, currency)
		{
			ConsumerId = consumerId;
		}
		/// <summary>
		/// Unique ID of the consumer that has to accept the payment. To retrieve the customer uid use the Retrive customer API (required with the MATCH_USER flow only)
		/// </summary>
		[JsonPropertyName("consumer_uid")]
		public string ConsumerId { get; set; }
	}
}
