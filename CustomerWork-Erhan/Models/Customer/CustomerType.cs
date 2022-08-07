using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWork_Erhan.Models.Customer
{
    public class CustomerType : BaseObject
    {
        [DisplayName("Müşteri Tipi Tanımı")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Description { get; set; }
    }
}
