using Satispay.Client.Models.Enum;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class CreatePaymentBase
	{
		/// <summary>
		/// The flow of the payment (MATCH_CODE, MATCH_USER, REFUND, PRE_AUTHORIZED, FUND_LOCK or PRE_AUTHORIZED_FUND_LOCK)
		/// </summary>
		[JsonPropertyName("flow")]
		public PaymentFlow Flow { get; }
		/// <summary>
		/// Amount of the payment in cents
		/// </summary>
		[JsonPropertyName("amount_unit")]
		public int AmountUnit { get; }
		/// <summary>
		/// Currency of the payment (only EUR currently supported)
		/// </summary>
		[JsonPropertyName("currency")]
		public Currency Currency { get; }
		/// <summary>
		/// Order ID or payment external identifier (max length allowed is 50 chars)
		/// </summary>
		[JsonPropertyName("external_code")]
		public string ExternalCode { get; set; }
		/// <summary>
		/// The url that will be called with an http GET request when the payment changes state. When url is called a Get payment details can be called to know the new Payment status. Note that {uuid} will be replaced with the Payment ID
		/// </summary>
		[JsonPropertyName("callback_url")]
		public string CallBackUrl { get; set; }
		/// <summary>
		/// The url to redirect the user after the payment flow is completed
		/// </summary>
		[JsonPropertyName("redirect_url")]
		public string RedirectUrl { get; set; }
		/// <summary>
		/// The expiration date of the payment
		/// </summary>
		[JsonPropertyName("expiration_date")]
		public string ExpirationDate { get; set; }
		/// <summary>
		/// Generic field that can be used to store generic info. The field phone_number can be used to pre-fill the mobile number. Use Constant.PhoneNumberMetaData
		/// </summary>
		[JsonPropertyName("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		public CreatePaymentBase(PaymentFlow flow, int amountUnit, Currency currency)
		{
			Flow = flow;
			AmountUnit = amountUnit;
			Currency = currency;
		}

	}
}
