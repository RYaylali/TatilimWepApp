

using System.ComponentModel.DataAnnotations;

namespace Tatilim.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Hizmet ikonu giriniz ")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage ="Hizmet başlığı giriniz ")]
        [MaxLength(100,ErrorMessage = "Hizmet başlığı en faala 100 karakter olabilir")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
