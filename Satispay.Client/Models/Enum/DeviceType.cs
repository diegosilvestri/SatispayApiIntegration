using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models.Enum
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum DeviceType
	{
		[Description("SMARTPHONE")]
		SMARTPHONE,
		[Description("TABLET")]
		TABLET,
		[Description("CASH-REGISTER")]
		CASH_REGISTER,
		[Description("POS")]
		POS,
		[Description("PC")]
		PC,
		[Description("ECOMMERCE_PLUGIN")]
		ECOMMERCE_PLUGIN
	}
}
