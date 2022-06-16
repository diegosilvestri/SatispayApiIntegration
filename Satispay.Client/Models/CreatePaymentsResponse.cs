using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class CreatePaymentsResponse : PaymentDetailsResponse
	{
		[JsonPropertyName("redirect_url")]
		public string RedirectUrl { get; set; }
	}
}
