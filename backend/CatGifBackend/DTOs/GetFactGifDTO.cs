namespace CatGifBackend.DTOs
{
    public class GetFactGifDTO
    {
        public string Fact { get; set; }
        public string? Query { get; set; }
        public string? GifUrl { get; set; }
        public int? Offset { get; set;}
    }
}
