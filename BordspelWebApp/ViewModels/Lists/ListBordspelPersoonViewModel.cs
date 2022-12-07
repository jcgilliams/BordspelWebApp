using BordspelWebApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Lists
{
    public class ListBordspelPersoonViewModel
    {
        public ICollection<BordspelPersoon> BordspelPersonen { get; set; }
        public ICollection<Persoon> Personen { get; set; }
        public ICollection<Rol> Rollen { get; set; }
        public ICollection<Bordspel> Bordspellen { get; set; }
    }
}
