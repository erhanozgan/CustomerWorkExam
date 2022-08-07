using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWork_Erhan.Models
{
    public class BaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 1 den başlayıp sırayla gidiyor id
        public int Id { get; set; }

    }
}
