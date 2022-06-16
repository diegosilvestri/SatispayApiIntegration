using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{


	public class ShopDailyClosureResponse
	{
		[JsonPropertyName("shop_daily_closure")]
		public ShopDailyClosure DailyClosure { get; set; }
		[JsonPropertyName("pdf")]
		public Pdf PdfDocument { get; set; }

		public class ShopDailyClosure

		{
			[JsonPropertyName("id")]
			public string Id { get; set; }
			[JsonPropertyName("type")]
			public string Type { get; set; }
			[JsonPropertyName("customer_uid")]
			public string CustomerUid { get; set; }
			[JsonPropertyName("amount_unit")]
			public int AmountUnit { get; set; }
			[JsonPropertyName("currency")]
			public string currency { get; set; }
		}
		public class Pdf
		{
			[JsonPropertyName("url")]
			public string url { get; set; }
			[JsonPropertyName("http_method")]
			public string HttpMethod { get; set; }
			[JsonPropertyName("expires_in_sec")]
			public int ExpiresInSec { get; set; }
			[JsonPropertyName("expiration")]
			public string expiration { get; set; }
			[JsonPropertyName("Key")]
			public string key { get; set; }
			[JsonPropertyName("bucket")]
			public string bucket { get; set; }
		}
	}


}
