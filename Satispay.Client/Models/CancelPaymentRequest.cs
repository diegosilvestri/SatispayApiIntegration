using Satispay.Client.Models.Enum;

namespace Satispay.Client.Models
{
	/// <summary>
	/// Cancel Payment
	/// </summary>
	public class CancelPaymentRequest : BaseUpdatePaymentRequest
	{
		public CancelPaymentRequest(int? amountUnit = null) : base(PaymentAction.CANCEL, amountUnit) { }


	}
}
