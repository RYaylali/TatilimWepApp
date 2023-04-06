using System.ComponentModel.DataAnnotations;

namespace Tatilim.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikonu giriniz ")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz ")]
        [MaxLength(100, ErrorMessage = "Hizmet başlığı en faala 100 karakter olabilir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması giriniz ")]
        [MaxLength(250, ErrorMessage = "Hizmet açıklaması en faala 250 karakter olabilir")]
        public string Description { get; set; }
    }
}
