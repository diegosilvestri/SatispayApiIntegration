using Satispay.Client.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Satispay.Client.Interface
{
	public class DefaultAuthenticationbuilder : ISatispayBuilder
	{
		public DefaultAuthenticationbuilder(IServiceCollection service)
		{
			Services = service;
		}
		public IServiceCollection Services { get; }
	}
}
