using System.Text.Json.Serialization;

namespace Satispay.Client.Models.Enum
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum PaymentAction
	{
		ACCEPT,
		CANCEL,
		CANCEL_OR_REFUND
	}
}
