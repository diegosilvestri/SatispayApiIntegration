using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Test
{
	public class TestHandler : DelegatingHandler
	{
		public TestHandler()
		{
			InnerHandler = new HttpClientHandler();
		}
		protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var body = await request.Content.ReadAsStringAsync();
			return await base.SendAsync(request, cancellationToken);
		}
	}

}
