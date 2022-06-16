using System;
using System.Net;

namespace Satispay.Client.Exceptions
{
	public class SotispayException : Exception
	{
		public string ErrorMessage { get; set; }
		public int Code { get; set; }
		public HttpStatusCode StatusCode { get; set; }

		public SotispayException(HttpStatusCode statusCode, int code, string errorMessage) : base(@$"Failed with HTTP status ""{statusCode}"", error ""{code}"", message ""{errorMessage}""")
		{
			StatusCode = statusCode;
			Code = code;
			ErrorMessage = errorMessage;
		}


	}
}
