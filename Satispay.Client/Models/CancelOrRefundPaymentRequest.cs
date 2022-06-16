using Satispay.Client.Models.Enum;

namespace Satispay.Client.Models
{
	/// <summary>
	/// Cancel Order Or Refund Payment
	/// </summary>
	public class CancelOrRefundPaymentRequest : BaseUpdatePaymentRequest
	{
		public CancelOrRefundPaymentRequest(int? amountUnit = null) : base(PaymentAction.CANCEL_OR_REFUND, amountUnit) { }


	}
}
