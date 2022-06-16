using Satispay.Client.Exceptions;
using Satispay.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Satispay.Client
{
	public class Utility
	{
		public static UrlEncoder Encoder = UrlEncoder.Default;
		public static async Task ThrowErrorIfAnyAsync(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
				return;

			var error = await response.Content.ReadFromJsonAsync<SatispayError>();
			if (error != null)
				throw new SotispayException(response.StatusCode, error.Code, error.Message);
		}

	}
}
