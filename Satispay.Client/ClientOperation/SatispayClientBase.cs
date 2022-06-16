using Satispay.Client.Exstension;
using Satispay.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Satispay.Client.ClientOperation
{
	public abstract class SatispayClientBase
	{
		public static async Task<SatispayResponse<T>> BuildResponse<T>(HttpResponseMessage response) where T : class
		{
			SatispayResponse<T> result = new SatispayResponse<T>();
			if (response.IsSuccessStatusCode)
			{
				result.Response = await response.Content.ReadFromJsonAsync<T>();
			}
			else
			{
				result.StatusCode = response.StatusCode;
				result.Error = await response.Content.ReadFromJsonAsync<SatispayError>();
				if (result.Error.IsNull())// Vuol dire che non si è riusciti a reperire l'errore
				{
					result.Error = new SatispayError();
					result.Error.Message = "Errore Non Gestito";
					result.Error.Code = 99;
				}
			}
			return result;
		}
	}
}
