using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CatGifBackend.Context
{
    public class Historial_catgif
    {
        [Key]
        [Column("id_cat")]
        public int id_cat { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }

        [Column("fact")]
        public string Fact { get; set; }

        [Column("query_text")]
        public string query_text { get; set; }

        [Column("gif_url")]
        public string gif_url { get; set; }
    }
}
