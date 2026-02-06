using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace QRCode_Generator.Models
{
    public class Mapping
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("domainUrl")]
        public string DomainUrl { get; set; }
        [Column("redirectionUrl")]
        public string RedirectionUrl { get; set; }
        [Column("isActivate")]
        public bool IsActivate { get; set; }
        [NotMapped]
        public string ImageBase64 { get; set; }
    }
}
