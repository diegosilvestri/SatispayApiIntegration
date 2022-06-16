using System.Text.Json.Serialization;

namespace Satispay.Client.Models.Enum
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum PaymentFlow
	{
		MATCH_CODE,
		MATCH_USER,
		REFUND,
		PRE_AUTHORIZED,
		FUND_LOCK,
		PRE_AUTHORIZED_FUND_LOCK
	}
}
