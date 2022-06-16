using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class MqttCertificateResponse
	{
		[JsonPropertyName("uid")]
		public string Uid { get; set; }
		[JsonPropertyName("shop_uid")]
		public string ShopUid { get; set; }
		[JsonPropertyName("CertificatePem")]
		public string certificate_pem { get; set; }
		[JsonPropertyName("PrivateKey")]
		public string private_key { get; set; }
	}
}
