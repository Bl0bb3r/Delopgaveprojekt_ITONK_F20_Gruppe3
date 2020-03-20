using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Models
{
    public partial class Vaerktoej
    {
        [Key]
        public long  VTID { get; set; }
        public string VTFabrikat { get; set; }
        public string VTSerienr { get; set; }
        public string VTModel { get; set; }
        public string VTType { get; set; }
        public DateTime VTAnskaffet { get; set; }
        public int? LiggerIvtk { get; set; }
        


    }
}
