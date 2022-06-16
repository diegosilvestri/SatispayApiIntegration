using Satispay.Client.Models.Enum;

namespace Satispay.Client.Models
{
	public class CreateMatchCodePaymentRequest : CreatePaymentBase
	{
		public CreateMatchCodePaymentRequest(int amountUnit, Currency currency) : base(PaymentFlow.MATCH_CODE, amountUnit, currency)
		{
		}
	}
}
