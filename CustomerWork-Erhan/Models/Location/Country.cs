using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWork_Erhan.Models.Location
{
    public class Country : BaseObject
    {
        [DisplayName("Ülke Tanımı")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Description { get; set; }

    }
}
