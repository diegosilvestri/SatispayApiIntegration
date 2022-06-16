namespace Satispay.Client.Interface
{
	public static class AuthenticationClientFactory
	{
		public static IAuthenticationSatispayClient GetAuthenticationClient(bool Production)
		{
			return new AuthenticationSatispayClient(Production);
		}

	}
}
