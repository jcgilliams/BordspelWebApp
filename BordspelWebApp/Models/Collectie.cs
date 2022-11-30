using BordspelWebApp.Areas.Data;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class Collectie
    {
        public int Id { get; set; }
        public Bordspel Bordspel { get; set; }
        [Required]
        public int BordspelId { get; set; }
        public Gebruiker Gebruiker {get; set;}
        public string GebruikersId { get; set; }
    }
}
