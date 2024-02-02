using System.Text.Json.Serialization;

namespace OnlineStore.API.DTO.Enums
{
	public enum CategoryEnums
	{
		[JsonPropertyName("men's clothing")]
		MensClothing,
		[JsonPropertyName("women's clothing")]
		WomensClothing,
		[JsonPropertyName("jewelery")]
		Jewelry,
		[JsonPropertyName("electronics")]
		Electronics
	}
}
