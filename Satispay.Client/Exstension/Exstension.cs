using System.ComponentModel;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Satispay.Client.Exstension
{
	public static class Exstension
	{
		public static HttpContent ToJsonContent(this object obj)
		{
			//var json = JsonSerializer.Serialize(obj, Costant.jsonSerializerOptions).Replace("\r", string.Empty);
			var json = JsonSerializer.Serialize(obj, Costant.jsonSerializerOptions);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}



		public static bool IsNotNull(this object obj)
		{
			return obj != null;
		}
		public static bool IsNull(this object obj)
		{
			return obj == null;
		}
		public static string DescriptionAttr<T>(this T source)
		{
			FieldInfo fi = source.GetType().GetField(source.ToString());

			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0) return attributes[0].Description;
			else return source.ToString();
		}
	}
}
