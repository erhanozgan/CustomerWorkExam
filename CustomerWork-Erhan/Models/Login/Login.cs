using System.ComponentModel;

namespace CustomerWork_Erhan.Models.Login
{
    public class Login : BaseObject
    {
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; } = string.Empty;   

        [DisplayName("Kullanıcı Şifre")]
        public string UserPassword { get; set; } = String.Empty;


    }
}
