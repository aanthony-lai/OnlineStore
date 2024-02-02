namespace OnlineStore.API.DTO
{
    public class UpdateProductDTO
    {
        public string title { get; set; } = string.Empty;
        public float price { get; set; }
        public string category { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
    }
}
