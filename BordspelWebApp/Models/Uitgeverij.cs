using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class Uitgeverij
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Website { get; set; }
        [Required]
        public string Land { get; set; }
        public ICollection<Uitgave> Uitgaves { get; set; }
    }
}
