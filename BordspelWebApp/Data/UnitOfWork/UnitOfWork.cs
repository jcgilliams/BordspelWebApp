using BordspelWebApp.Data.Repositories;
using BordspelWebApp.Models;
using System.Threading.Tasks;

namespace BordspelWebApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BordspelWebAppContext _context;
        private IGenericRepository<Bordspel> _genericBordspelRepository;
        private IGenericRepository<BordspelPersoon> _genericBordspelPersoonRepository; 
        private IGenericRepository<Persoon> _genericPersoonRepository;
        private IGenericRepository<Rol> _genericRolRepository;
        private IGenericRepository<Uitgave> _genericUitgaveRepository; 
        private IGenericRepository<Uitgeverij> _genericUitgeverijRepository;
        public ICollectieRepository _collectieRepository;
        public UnitOfWork(BordspelWebAppContext context)
        {
            _context = context;
        }

        public IGenericRepository<Bordspel> BordspelRepo
        {
            get
            {
                if (this._genericBordspelRepository == null)
                {
                    this._genericBordspelRepository = new GenericRepository<Bordspel>(_context);
                }
                return _genericBordspelRepository;
            }
        }

        public IGenericRepository<BordspelPersoon> BordspelPersoonRepo
        {
            get
            {
                if (this._genericBordspelPersoonRepository == null)
                {
                    this._genericBordspelPersoonRepository = new GenericRepository<BordspelPersoon>(_context);
                }
                return _genericBordspelPersoonRepository;
            }
        }

        public IGenericRepository<Persoon> PersoonRepo
        {
            get
            {
                if (this._genericPersoonRepository == null)
                {
                    this._genericPersoonRepository = new GenericRepository<Persoon>(_context);
                }
                return _genericPersoonRepository;
            }

        }

        public IGenericRepository<Rol> RolRepo
        {
            get
            {
                if (this._genericRolRepository == null)
                {
                    this._genericRolRepository = new GenericRepository<Rol>(_context);
                }
                return _genericRolRepository;
            }
        }

        public IGenericRepository<Uitgave> UitgaveRepo
        {
            get
            {
                if (this._genericUitgaveRepository == null)
                {
                    this._genericUitgaveRepository = new GenericRepository<Uitgave>(_context);
                }
                return _genericUitgaveRepository;
            }
        }

        public IGenericRepository<Uitgeverij> UitgeverijRepo
        {
            get
            {
                if (this._genericUitgeverijRepository == null)
                {
                    this._genericUitgeverijRepository = new GenericRepository<Uitgeverij>(_context);
                }
                return _genericUitgeverijRepository;
            }
        }

        public ICollectieRepository CollectieRepository
        {
            get
            {
                if(this._collectieRepository == null)
                {
                    this._collectieRepository = new CollectieRepository(_context);
                }
                return _collectieRepository;
            }
        }

        public Task Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
