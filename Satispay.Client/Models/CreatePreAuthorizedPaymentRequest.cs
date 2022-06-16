using Satispay.Client.Models.Enum;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class CreatePreAuthorizedPaymentRequest : CreatePaymentBase
	{
		public CreatePreAuthorizedPaymentRequest(int amountUnit, Currency currency) : base(PaymentFlow.PRE_AUTHORIZED, amountUnit, currency)
		{
		}
		/// <summary>
		/// Pre-Authorized token id (required with the PRE_AUTHORIZED flow only)
		/// </summary>
		[JsonPropertyName("pre_authorized_payments_token")]
		public string PreAuthorizedPaymentsToken { get; set; }
	}
}
