using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.Models
{
    public class Collectie
    {
        public int Id { get; set; }
        public Bordspel Bordspel { get; set; }
        [Required]
        public int BordspelId { get; set; }

        // nog te doen
        // public Gebruiker Gebruiker {get; set;}
        // [Required]
        // public string GebruikerId {get; set;}
    }
}
