using BordspelWebApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.Repositories
{
    public interface IUitgaveRepository
    {
        Task<Uitgave> GetById(int bordspelId);
        IQueryable<Uitgave> GetAll();
    }
}
