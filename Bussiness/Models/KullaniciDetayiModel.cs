using DataAccess.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class KullaniciDetayiModel
    {               
        [Required]
        [StringLength(200)]
        [EmailAddress(ErrorMessage ="{0} format� uygun de�ildir!")]
        [DisplayName("E-Posta")]
        public string Eposta { get; set; }
        public Cinsiyetler Cinsiyet { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required(ErrorMessage ="�lke se�iniz...")]
        [DisplayName("�lke")]
        public int? UlkeId { get; set; }
        [Required(ErrorMessage ="�ehir se�iniz...")]
        [DisplayName("�ehir")]
        public int? SehirId { get; set; }
        
    }
}
