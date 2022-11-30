using BordspelWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.Repositories
{
    public class CollectieRepository : GenericRepository<Collectie>,  ICollectieRepository
    {
        private readonly BordspelWebAppContext _context;
        public CollectieRepository(BordspelWebAppContext context):base(context)
        {
            
        }
        public override IQueryable<Collectie> GetAll()
        {
            return _context.Collecties.Include(c => c.Bordspel).AsQueryable(); // als in model collectie ook link naar gebruiker klaar is, moet deze ook include
        }

        public override async Task<Collectie> GetById(int collectieId)
        {
            return await _context.Collecties
                .Where(c => c.Id == collectieId)
                .Include(c => c.Bordspel) // idem hierboven, ook extra include doen naar gebruiker
                .FirstOrDefaultAsync();
        }
    }
}
