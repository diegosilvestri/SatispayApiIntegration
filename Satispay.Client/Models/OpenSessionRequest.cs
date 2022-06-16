using System;
using System.Text.Json.Serialization;

namespace Satispay.Client.Models
{
	public class OpenSessionRequest
	{
		public OpenSessionRequest(string fundLockUid)
		{
			if (string.IsNullOrEmpty(fundLockUid))
				throw new ArgumentNullException("FundLockUid non valorizzato!");
			FundLockUid = fundLockUid;
		}

		[JsonPropertyName("fund_lock_uid")]
		public string FundLockUid { get; set; }
	}
}
