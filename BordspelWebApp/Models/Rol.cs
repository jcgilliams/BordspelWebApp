using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class Rol
    {
        public int Id { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        public ICollection<BordspelPersoon> BordspelPersonen { get; set; }
    }
}
