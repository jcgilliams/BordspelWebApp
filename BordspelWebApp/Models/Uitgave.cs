using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class Uitgave
    {
        public int Id { get; set; }
        [Required]
        public int BordspelId { get; set; }
        [Required]
        public int UitgeverijId { get; set; }
        public string Taal { get; set; }
        public Bordspel Bordspel { get; set; }
        public Uitgeverij Uitgeverij { get; set; }
    }
}
