using System.Net;

namespace Satispay.Client.Models
{
	public class SatispayResponse<T> where T : class
	{
		public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
		public SatispayError Error { get; set; }
		public T Response { get; set; }
	}
}
