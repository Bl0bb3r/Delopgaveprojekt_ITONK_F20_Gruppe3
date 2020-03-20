using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Models
{
    public partial class Haandvaerker
    {
        public Haandvaerker()
        {
            Vaerktoejskasse = new HashSet<Vaerktoejskasse>();
        }
        [Key]
        public int HaandvaerkerID { get; set; }
        public string HVFornavn { get; set; }
        public string HVEfternavn { get; set; }
        public DateTime HVAnsaettelsedato { get; set; }
        public string HVFagomraade { get; set; }
        public HashSet<Vaerktoejskasse> Vaerktoejskasse { get; set; }
        
    }
}
