using AppCorev1.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Urun : RecordBase
    {
        [Required]
        [StringLength(300)]
        public string Adi { get; set; }
        [StringLength(500)]
        public string Aciklamasi { get; set; }        
        [StringLength(20)]
        public string Renk { get; set; }
        [StringLength(50)]
        public string Boyut { get; set; }
        public int MarkaId { get; set; }
        public Marka Marka { get; set; } //bir ürünün bir markasý olabilir     

    }
}
