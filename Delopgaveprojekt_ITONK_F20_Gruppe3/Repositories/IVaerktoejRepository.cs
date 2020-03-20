using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories
{
    public interface IVaerktoejRepository
    {
        void AddVaerktoej(Vaerktoej vaerktoej);
        List<Vaerktoej> GetVaerktoej();
        Vaerktoej GetById(int id);
        void UpdateVaerktoej(int id);
        void DeleteVaertoej(int id);
    }
}
