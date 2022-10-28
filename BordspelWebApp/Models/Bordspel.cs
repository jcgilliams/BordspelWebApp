using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class Bordspel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gelieve een naam in te vullen aub.")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Gelieve een releasejaar in te vullen aub.")]
        public int Jaar { get; set; }
        public string Beschrijving { get; set; }
        public int? MinAantalSpelers { get; set; }
        public int? MaxAantalSpelers { get; set; }
        public int? MinSpeeltijd { get; set; }
        public int? MaxSpeeltijd { get; set; }
        public int? Leeftijd { get; set; }
        public string Afbeelding { get; set; }
        public ICollection<BordspelPersoon> BordspelPersonen { get; set; }
        public ICollection<Collectie> Collecties { get; set; }
        public ICollection<Uitgave> Uitgaves { get; set; }
    }
}
