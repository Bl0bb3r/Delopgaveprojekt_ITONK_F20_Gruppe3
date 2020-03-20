using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.AppDB
{
    public interface IDatabaseFactory
    {
        IDatabase GetDatabase();
    }
}
