using System.Collections.Generic;

namespace Satispay.Client.Models
{
	public class OptionalInformationWithIdempotencyKey : OptionalInformation
	{

		public string IdempotencyKey { get; }
		/// <summary>
		/// The idempotent token of the request
		/// </summary>
		/// <param name="idempotencyKey">The idempotent token of the request</param>
		public OptionalInformationWithIdempotencyKey(string idempotencyKey = "")
		{
			IdempotencyKey = idempotencyKey;
		}

		public override Dictionary<string, string> GetHeaderOptionalInformation()
		{
			var headerInformation = base.GetHeaderOptionalInformation();
			if (!string.IsNullOrEmpty(IdempotencyKey))
				headerInformation.Add("Idempotency-Key", IdempotencyKey);

			return headerInformation;
		}

	}
}
