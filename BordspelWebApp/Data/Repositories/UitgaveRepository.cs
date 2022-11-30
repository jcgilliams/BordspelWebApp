using BordspelWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.Repositories
{
    public class UitgaveRepository : GenericRepository<Uitgave>, IUitgaveRepository
    {
        private readonly BordspelWebAppContext _context;
        public UitgaveRepository(BordspelWebAppContext context) : base(context)
        {

        }
        public override IQueryable<Uitgave> GetAll()
        {
            return _context.Uitgaven.Include(u => u.Bordspel).Include(u => u.Uitgeverij).AsQueryable();
        }

        public override async Task<Uitgave> GetById(int bordspelId)
        {
            return await _context.Uitgaven
                .Where(c => c.Id == bordspelId)
                .Include(u => u.Bordspel)
                .Include(u => u.Uitgeverij)
                .FirstOrDefaultAsync();
        }
    }
}
