using BordspelWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.Repositories
{
    public interface ICollectieRepository
    {
        Task<Collectie> GetById(int collectieId);
        IQueryable<Collectie> GetAll();
    }
}
