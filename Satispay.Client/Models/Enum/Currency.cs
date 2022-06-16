using System.Text.Json.Serialization;

namespace Satispay.Client.Models.Enum
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum Currency
	{
		EUR,
	}
}
