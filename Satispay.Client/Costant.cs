using System.Text.Json;

namespace Satispay.Client
{
	public static class Costant
	{
		public static string StagingBaseUrl = "https://staging.authservices.satispay.com/g_business/";
		public static string ProductionBaseUrl = "https://authservices.satispay.com/g_business/";
		public static string PhoneNumberMetaData = "phone_number";
		public static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
		{
			WriteIndented = false,
			DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
		};

	}
}
