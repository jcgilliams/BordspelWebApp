using BordspelWebApp.Models;
using System.Collections.Generic;

namespace BordspelWebApp.ViewModels.Lists
{
    public class ListPersonenBeheerViewModel
    {
        public ICollection<Persoon> Personen { get; set; }
    }
}
