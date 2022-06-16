using Satispay.Client.Exstension;
using Satispay.Client.Models.Enum;
using System.Collections.Generic;

namespace Satispay.Client.Models
{
	public class OptionalInformation
	{
		/// <summary>
		/// info about the device
		/// </summary>
		public string DeviceInfo { get; set; } = string.Empty;
		/// <summary>
		/// Operative System name
		/// </summary>
		public string OperativeSystemName { get; set; } = string.Empty;
		/// <summary>
		/// Device Type
		/// </summary>
		public DeviceType? DeviceType { get; set; }
		/// <summary>
		/// Operative System version
		/// </summary>
		public string OperativeSystemVersion { get; set; } = string.Empty;
		/// <summary>
		/// Software house name
		/// </summary>
		public string SoftwareHouseName { get; set; } = string.Empty;
		/// <summary>
		/// Software Name
		/// </summary>
		public string SoftwareName { get; set; } = string.Empty;
		/// <summary>
		/// Software Versione
		/// </summary>
		public string SoftwareVersion { get; set; } = string.Empty;
		/// <summary>
		/// x-satispay-tracking-code
		/// </summary>
		public string TrackingCode { get; set; } = string.Empty;

		public virtual Dictionary<string, string> GetHeaderOptionalInformation()
		{
			Dictionary<string, string> header = new Dictionary<string, string>();
			if (!string.IsNullOrWhiteSpace(DeviceInfo))
				header.Add("x-satispay-deviceinfo", DeviceInfo);

			if (!string.IsNullOrWhiteSpace(OperativeSystemName))
				header.Add("x-satispay-os", OperativeSystemName);

			if (!string.IsNullOrWhiteSpace(OperativeSystemVersion))
				header.Add("x-satispay-osv", OperativeSystemVersion);

			if (DeviceType.IsNotNull())
				header.Add("x-satispay-devicetype", DeviceType.DescriptionAttr());

			if (!string.IsNullOrWhiteSpace(SoftwareHouseName))
				header.Add("x-satispay-apph", SoftwareHouseName);

			if (!string.IsNullOrWhiteSpace(SoftwareName))
				header.Add("x-satispay-appn", SoftwareName);

			if (!string.IsNullOrWhiteSpace(SoftwareVersion))
				header.Add("x-satispay-appv", SoftwareVersion);

			if (!string.IsNullOrWhiteSpace(TrackingCode))
				header.Add("x-satispay-tracking-code", TrackingCode);

			return header;
		}

	}
}
