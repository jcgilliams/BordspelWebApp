using BordspelWebApp.Models;
using System.Collections.Generic;

namespace BordspelWebApp.ViewModels.Lists
{
    public class ListUitgaveBeheerViewModel
    {
        public ICollection<Uitgave> Uitgaves { get; set; }
        public ICollection<Uitgeverij> Uitgeverijen { get; set; }
        public ICollection<Bordspel> Bordspellen { get; set; }
    }
}
