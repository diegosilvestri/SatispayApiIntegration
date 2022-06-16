using Satispay.Client.Models.Enum;

namespace Satispay.Client.Models
{
	/// <summary>
	/// Accept Payment
	/// </summary>
	public class AcceptPaymentRequest : BaseUpdatePaymentRequest
	{
		public AcceptPaymentRequest(int? amountUnit = null) : base(PaymentAction.ACCEPT, amountUnit) { }


	}
}
