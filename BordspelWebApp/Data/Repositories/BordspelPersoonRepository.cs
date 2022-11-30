using BordspelWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.Repositories
{
    public class BordspelPersoonRepository : GenericRepository<BordspelPersoon>, IBordspelPersoonRepository
    {
        private readonly BordspelWebAppContext _context;
        public BordspelPersoonRepository(BordspelWebAppContext context) : base(context)
        {
        }
        public override IQueryable<BordspelPersoon> GetAll()
        {
            return _context.BordspelPersonen.Include(b => b.Bordspel).Include(b => b.Rol).Include(b => b.Persoon).AsQueryable();
        }

        public override async Task<BordspelPersoon> GetById(int bordspelId)
        {
            return await _context.BordspelPersonen
                .Where(bp => bp.Id == bordspelId)
                .Include(bp => bp.Bordspel)
                .Include(bp => bp.Rol)
                .Include(bp => bp.Persoon)
                .FirstOrDefaultAsync();
        }
    }
}
