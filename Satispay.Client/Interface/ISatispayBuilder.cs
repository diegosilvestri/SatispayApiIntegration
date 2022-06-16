using Microsoft.Extensions.DependencyInjection;

namespace Satispay.Client.Interface
{
	public interface ISatispayBuilder
	{
		IServiceCollection Services { get; }
	}
}
