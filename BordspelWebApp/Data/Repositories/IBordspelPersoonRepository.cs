using BordspelWebApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.Repositories
{
    public interface IBordspelPersoonRepository
    {
        Task<BordspelPersoon> GetById(int bordspelId);
        IQueryable<BordspelPersoon> GetAll();
    }
}
