using AppCorev1.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class UrunModel : RecordBase
    {
        #region
        [Required(ErrorMessage = "{0} gereklidir!")]
        [StringLength(300, ErrorMessage = "{0} maksimum {1} karakter olmalýdýr!")]
        [DisplayName("Adý")]
        public string Adi { get; set; }
        [StringLength(500, ErrorMessage = "{0} maksimum {1} karakter olmalýdýr!")]
        [DisplayName("Açýklamasý")]
        public string Aciklamasi { get; set; }
        [StringLength(20, ErrorMessage = "{0} maksimum {1} karakter olmalýdýr!")]
        public string Renk { get; set; }
        [StringLength(50, ErrorMessage = "{0} maksimum {1} karakter olmalýdýr!")]
        public string Boyut { get; set; }
        public int? MarkaId { get; set; }
        
        #endregion
        #region
       
        [DisplayName("Marka")]
        public string MarkaAdiDisplay { get; set; }

        public List<string> MarkalarDisplay { get; set; }       


        #endregion





    }
}
