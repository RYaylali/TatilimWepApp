using System.ComponentModel.DataAnnotations;

namespace Tatilim.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Lütfen isim giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Lütfen soyad giriniz")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen tekrar şifresini giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
		public int WorkLocationID { get; set; }
	}
}
