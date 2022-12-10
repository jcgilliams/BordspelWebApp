using BordspelWebApp.Areas.Data;
using BordspelWebApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Delete
{
    public class DeleteBordspelUitCollectieModelView
    {
        public int Id { get; set; }
        [Required]
        public int BordspelId { get; set; }
        [Required]
        public string GebruikerId { get; set; }
        public ICollection<Gebruiker> Gebruikers { get; set; }
        public ICollection<Bordspel> Bordspellen { get; set; }
        public Bordspel Bordspel { get; set; }
        public ICollection<Collectie> Collecties { get; set; }
    }
}
