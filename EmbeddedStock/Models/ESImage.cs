using System.ComponentModel.DataAnnotations;

namespace EmbeddedStock.Models
{
    // ReSharper disable once InconsistentNaming
    public class ESImage
    {
        // ReSharper disable once InconsistentNaming
        public long ESImageId { get; set; }
        [MaxLength(128)]
        public string ImageMimeType { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] ImageData { get; set; }
    }
}