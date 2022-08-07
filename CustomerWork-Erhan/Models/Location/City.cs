using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWork_Erhan.Models.Location
{
    public class City : BaseObject
    {

        [DisplayName("Şehir Tanımı")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Ülke Id'si")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }


    }
}
