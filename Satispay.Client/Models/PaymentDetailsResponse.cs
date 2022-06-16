using Satispay.Client.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class PaymentDetailsResponse
	{
		/// <summary>
		/// Unique ID of the payment.
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; }
		/// <summary>
		///  Generated code identifier
		/// </summary>
		[JsonPropertyName("code_identifier")]
		public string CodeIdentifier { get; set; }
		/// <summary>
		/// Type of payment (TO_BUSINESS or REFUND_TO_BUSINESS)
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; set; }
		/// <summary>
		/// Amount of the payment in cents
		/// </summary>
		[JsonPropertyName("amount_unit")]
		public int AmountUnit { get; set; }
		/// <summary>
		/// Currency of the payment
		/// </summary>
		[JsonPropertyName("currency")]
		public Currency Currency { get; set; }
		/// <summary>
		///  Status of the payment (PENDING, ACCEPTED, CANCELED or AUTHORIZED)
		/// </summary>
		[JsonPropertyName("status")]
		public PaymentStatus Status { get; set; }
		/// <summary>
		/// If true, the payment is expired
		/// </summary>
		[JsonPropertyName("expired")]
		public bool Expired { get; set; }
		/// <summary>
		/// Additional metadata of the payment
		/// </summary>
		[JsonPropertyName("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
		/// <summary>
		/// The sender actor of the payment
		/// </summary>
		[JsonPropertyName("sender")]
		public SenderResource Sender { get; set; }
		/// <summary>
		/// The receiver actor of the payment
		/// </summary>
		[JsonPropertyName("receiver")]
		public ReceiverResource Receiver { get; set; }
		/// <summary>
		/// The daily closure of the payment
		/// </summary>
		[JsonPropertyName("daily_closure")]
		public DailyClosureResource DailyClosure { get; set; }
		/// <summary>
		/// Timestamp of payment insertion
		/// </summary>
		[JsonPropertyName("insert_date")]
		public DateTime InsertDate { get; set; }
		/// <summary>
		/// Timestamp of payment expiration
		/// </summary>
		[JsonPropertyName("expire_date")]
		public DateTime ExpireDate { get; set; }
		/// <summary>
		/// Order ID or payment external identifier
		/// </summary>
		[JsonPropertyName("external_code")]
		public string ExternalCode { get; set; }

		/// <summary>
		/// The sender actor of the payment
		/// </summary>
		public class SenderResource
		{
			/// <summary>
			/// Unique ID of the sender
			/// </summary>
			[JsonPropertyName("id")]
			public string Id { get; set; }
			/// <summary>
			///  Type of the actor (CONSUMER)
			/// </summary>
			[JsonPropertyName("type")]
			public string Type { get; set; }
			/// <summary>
			/// Short name of the actor
			/// </summary>
			[JsonPropertyName("name")]
			public string Name { get; set; }
		}
		/// <summary>
		/// The receiver actor of the payment
		/// </summary>
		public class ReceiverResource
		{
			/// <summary>
			/// Unique ID of the receiver
			/// </summary>
			[JsonPropertyName("id")]
			public string Id { get; set; }
			/// <summary>
			/// Type of the actor (SHOP)
			/// </summary>
			[JsonPropertyName("type")]
			public string Type { get; set; }
		}
		/// <summary>
		/// The daily closure of the payment
		/// </summary>
		public class DailyClosureResource
		{
			/// <summary>
			/// ID of the daily closure
			/// </summary>
			[JsonPropertyName("id")]
			public string Id { get; set; }
			/// <summary>
			/// The closure date
			/// </summary>
			[JsonPropertyName("type")]
			public string Type { get; set; }
		}
	}
}
