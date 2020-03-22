using Microsoft.EntityFrameworkCore.Storage;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.AppDB
{
    public interface IDatabaseFactory
    {
        IDatabase GetDatabase();
    }
}
