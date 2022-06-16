using Satispay.Client.Models.Enum;

namespace Satispay.Client.Models
{
	public class CreatePreAuthorizedFundLockPaymentRequest : CreatePaymentBase
	{
		public CreatePreAuthorizedFundLockPaymentRequest(int amountUnit, Currency currency) : base(PaymentFlow.PRE_AUTHORIZED_FUND_LOCK, amountUnit, currency)
		{
		}

	}
}
