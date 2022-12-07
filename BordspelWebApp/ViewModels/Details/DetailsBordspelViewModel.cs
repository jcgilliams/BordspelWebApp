using BordspelWebApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Details
{
    public class DetailsBordspelViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Jaar { get; set; }
        public string Beschrijving { get; set; }
        public int? MinAantalSpelers { get; set; }
        public int? MaxAantalSpelers { get; set; }
        public int? MinSpeeltijd { get; set; }
        public int? MaxSpeeltijd { get; set; }
        public int? Leeftijd { get; set; }
        public string Afbeelding { get; set; }
        public ICollection<BordspelPersoon> BordspelPersonen { get; set; }
        public ICollection<Uitgave> Uitgaves { get; set; }
    }
}
