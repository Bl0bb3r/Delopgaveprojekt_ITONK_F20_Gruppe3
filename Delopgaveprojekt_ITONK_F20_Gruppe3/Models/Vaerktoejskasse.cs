using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Models
{
    public partial class Vaerktoejskasse
    {
        public Vaerktoejskasse()
        {
            Vaerktoej = new HashSet<Vaerktoej>();
        }
        [Key]
        public int VTKID { get; set; }
        public string VTKFabrikat { get; set; }
        public string VTKSerienummer { get; set; }
        public string VTKModel { get; set; }
        public string VTKFarve { get; set; }
        public int? VTKEjesAf { get; set; }
        public DateTime VTKAnskaffet { get; set; }
        public HashSet<Vaerktoej> Vaerktoej { get; set; }




    }
}
