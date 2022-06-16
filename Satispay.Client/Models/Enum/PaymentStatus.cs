using System.Text.Json.Serialization;

namespace Satispay.Client.Models.Enum
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum PaymentStatus
	{
		ACCEPTED,
		PENDING,
		CANCELED,
		AUTHORIZED
	}
}
