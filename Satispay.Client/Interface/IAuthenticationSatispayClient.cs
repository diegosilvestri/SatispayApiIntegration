using Satispay.Client.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Satispay.Client.Interface
{
	public interface IAuthenticationSatispayClient : IDisposable
	{
		Task<SatispayResponse<KeyIdResponse>> GetKeyId(string publicKey, string token, CancellationToken cancellationToken);
	}
}