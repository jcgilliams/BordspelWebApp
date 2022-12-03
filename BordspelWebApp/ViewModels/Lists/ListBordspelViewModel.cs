using BordspelWebApp.Models;
using System.Collections.Generic;

namespace BordspelWebApp.ViewModels.Lists
{
    public class ListBordspelViewModel
    {
        public ICollection<Bordspel> Bordspellen { get; set; }
        public string SpelZoeken { get; set; }
    }
}
