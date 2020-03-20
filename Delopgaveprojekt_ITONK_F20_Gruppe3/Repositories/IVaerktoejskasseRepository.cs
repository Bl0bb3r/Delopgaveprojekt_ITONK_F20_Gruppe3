using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories
{
    public interface IVaerktoejskasseRepository
    {
        void AddVaerktøjskasse(Vaerktoejskasse vaerktoejskasse);
        List<Vaerktoejskasse> GetVaerktoejskasse();
        Vaerktoejskasse GetById(int id);
        void UpdateVaerktoejskasse(int id);
        void DeleteVaerktoejskasse(int id);
    }
}
