using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWork_Erhan.Models.Customer
{
    public class CustomerRep : BaseObject
    {
        [Required]
        [DisplayName("Müşteri Id'si")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }


        [DisplayName("Ad")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        [DisplayName("Soyad")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Surname { get; set; }

        [DisplayName("Mail")]
        [EmailAddress]
        [Column(TypeName = "nvarchar(50)")]
        public string? Email { get; set; }

        [DisplayName("Telefon")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Telephone { get; set; }
    }
}
