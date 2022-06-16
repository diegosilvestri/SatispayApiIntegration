using Satispay.Client.Models.Enum;

namespace Satispay.Client.Models
{
	public class CreateFundLockPaymentRequest : CreatePaymentBase
	{
		public CreateFundLockPaymentRequest(int amountUnit, Currency currency) : base(PaymentFlow.FUND_LOCK, amountUnit, currency)
		{
		}

	}
}
