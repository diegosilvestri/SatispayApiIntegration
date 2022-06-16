using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class CreateAuthorizationRequest
	{
		/// <summary>
		/// The reason why the token is being request
		/// </summary>
		[JsonPropertyName("reason")]
		public string Reason { get; set; }
		/// <summary>
		/// The url that will be called with an http GET request if the pre-authorization status changes. Note that {uuid} will be replaced with the authorization token
		/// </summary>
		[JsonPropertyName("callback_url")]
		public string CallbackUrl { get; set; }
		/// <summary>
		/// The url to redirect the user after the authorization flow is completed
		/// </summary>
		[JsonPropertyName("redirect_url")]
		public string RedirectUrl { get; set; }
		/// <summary>
		/// Generic field that can be used to store generic info. The field phone_number can be used to pre-fill the mobile number Use Costant.PhoneNumberMetaData  
		/// </summary>
		[JsonPropertyName("metadata")]
		public Dictionary<string, string> Metadata { get; }
	}
}
