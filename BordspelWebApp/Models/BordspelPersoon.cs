using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class BordspelPersoon
    {
        public int Id { get; set; }
        [Required]
        public int BordspelId { get; set; }
        [Required]
        public int PersoonId { get; set; }
        [Required]
        public int RolId { get; set; }
        public Persoon Persoon { get; set; }
        public Rol Rol { get; set; }
        public Bordspel Bordspel { get; set; }
    }
}
