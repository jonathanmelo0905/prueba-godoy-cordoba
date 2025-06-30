namespace CatGifBackend.DTOs
{
    public class GetFactGifDTO
    {
        public string? Fact { get; set; } = string.Empty;
        public string? Query { get; set; } = string.Empty;
        public string? GifUrl { get; set; } = string.Empty;
        public int? Offset { get; set;}
    }
}
