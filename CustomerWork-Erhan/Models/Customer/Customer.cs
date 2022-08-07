using CustomerWork_Erhan.Models.Location;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWork_Erhan.Models.Customer
{
    public class Customer : BaseObject
    {
        [DisplayName("Müşteri Kodu")]
        [Column(TypeName = "nvarchar(10)")]
        public int CustomerCode { get; set; }

        [DisplayName("Müşteri Tanımı")]
        [Column(TypeName = "nvarchar(150)")]
        public string? CustomerDescription { get; set; }

        [Required]
        [DisplayName("Müşteri Tipi Id'si")]
        public int CustomerTypeId { get; set; }
        public CustomerType? CustomerType { get; set; }

        [Required]
        [DisplayName("Ülke Id'si")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        [Required]
        [DisplayName("Şehir Id'si")]
        public int CityId { get; set; }
        public City? City { get; set; }

        [DisplayName("Adres")]
        [Column(TypeName = "nvarchar(150)")]
        public int Address { get; set; }

      [ScaffoldColumn(false)]
        public bool Active { get; set; }

        [DisplayName("Aktif")]
        public string IsActiveString => Active ? "Aktif" : "Pasif";

    }
}
