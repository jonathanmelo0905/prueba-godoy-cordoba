namespace CatGifBackend.Models
{
    public class GiphyResponse
    {
        public List<GifData>? Data { get; set; }
    }

    public class GifData
    {
        public GifImages? Images { get; set; }
    }

    public class GifImages
    {
        public GifOriginal? Original { get; set; }
    }

    public class GifOriginal
    {
        public string? Url { get; set; }
    }
}
