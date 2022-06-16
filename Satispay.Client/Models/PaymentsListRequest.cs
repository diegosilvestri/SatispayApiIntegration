using Satispay.Client.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Satispay.Client.Models
{
	public class PaymentsListRequest
	{
		/// <summary>
		/// Filter by the payment status ACCEPTED, PENDING or CANCELED
		/// </summary>
		public PaymentStatus? Status { get; set; }
		/// <summary>
		/// A limit on the number of objects to be returned, between 1 and 100
		/// </summary>
		public int? Limit { get; set; }
		/// <summary>
		/// Is the id that defines your place in the list when you make a payment list request
		/// </summary>
		public string StartingAfter { get; set; }

		public DateTime? StartingAfterTimestamp { get; set; }
		/// <summary>
		/// Is the timestamp (in milliseconds) that defines your place in the list when you make a payment list request
		/// </summary>
		public OptionalInformation OptionalInfo { get; set; }


		public PaymentsListRequest(PaymentStatus? status = null, int? limit = null,
								   string startingAfter = "", DateTime? startingAfterTimestamp = null, OptionalInformation optionalInfo = null)
		{
			Status = status;
			Limit = limit;
			StartingAfter = startingAfter;
			StartingAfterTimestamp = startingAfterTimestamp;
			OptionalInfo = optionalInfo;
		}

		public string GetQueryString()
		{
			Dictionary<string, string> header = new Dictionary<string, string>();

			if (Status.HasValue)
				header.Add("status", Status.ToString());
			if (Limit.HasValue)
				header.Add("limit", Limit.ToString());

			if (!string.IsNullOrWhiteSpace(StartingAfter))
				header.Add("starting_after", StartingAfter);

			if (StartingAfterTimestamp.HasValue)
				header.Add("starting_after_timestamp", StartingAfterTimestamp.Value.Ticks.ToString());


			var querystring = string.Join("&", header.Select(x => $"{Utility.Encoder.Encode(x.Key)}={Utility.Encoder.Encode(x.Value)}"));

			var result = string.Empty;
			if (querystring.Length > 1)
				result = $"?{querystring}";

			return result;
		}
	}
}
