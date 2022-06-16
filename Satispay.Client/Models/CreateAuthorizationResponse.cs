using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class CreateAuthorizationResponse : AuthorizationResponseBase
	{

		/// <summary>
		/// Redirect url to the authorization page
		/// </summary>
		[JsonPropertyName("redirect_url")]
		public string RedirectUrl { get; set; }
	}
}
