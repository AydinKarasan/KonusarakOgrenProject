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
    public class MarkaModel : RecordBase
    {
        #region
        [Required(ErrorMessage = "{0} gereklidir!")]
        [StringLength(100, ErrorMessage = "{0} maksimum {1} karakter olmalýdýr!")]
        [DisplayName("Adý")]
        public string Adi { get; set; }
        #endregion
        #region
        [DisplayName("Ürün Sayýsý")]
        public int UrunSayisiDisplay { get; set; }
        #endregion
    }
}
