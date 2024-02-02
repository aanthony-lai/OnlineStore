using System.Text.Json.Serialization;

namespace OnlineStore.API.Helpers
{
	public static class GetEnumString
	{
		public static string GetEnumStringValue(Enum value)
		{
			var type = value.GetType();
			var name = Enum.GetName(type, value);
			return type.GetField(name)
					   .GetCustomAttributes(false)
					   .OfType<JsonPropertyNameAttribute>()
					   .SingleOrDefault()
					   ?.Name ?? name;
		}
	}
}
