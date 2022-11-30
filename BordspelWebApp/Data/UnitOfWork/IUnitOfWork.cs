using BordspelWebApp.Data.Repositories;
using BordspelWebApp.Models;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Bordspel> BordspelRepo { get; }
        IGenericRepository<BordspelPersoon> BordspelPersoonRepo { get; }
        IGenericRepository<Persoon> PersoonRepo { get; }
        IGenericRepository<Rol> RolRepo { get; }
        IGenericRepository<Uitgave> UitgaveRepo { get; }
        IGenericRepository<Uitgeverij> UitgeverijRepo { get; }
        ICollectieRepository CollectieRepository { get; }
        Task Save();
    }
}
