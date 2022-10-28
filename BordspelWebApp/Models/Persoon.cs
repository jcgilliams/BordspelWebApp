using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class Persoon
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        public string Beschrijving { get; set; }
        public ICollection<BordspelPersoon> BordspelPersonen { get; set; }
    }
}
