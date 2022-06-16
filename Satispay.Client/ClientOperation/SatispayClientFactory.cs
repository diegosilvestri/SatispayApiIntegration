using Satispay.Client.Interface;

namespace Satispay.Client.ClientOperation
{
	public static class SatispayClientFactory
	{
		public static ISatispayClient GetClient(string keyId, string privateKey, bool production)
		{
			return new SatispayClient(keyId, privateKey, production);

		}

	}
}
