using BordspelWebApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Create
{
    public class CreateBordspelPersoonViewModel
    {
        [Required(ErrorMessage = "Gelieve een bordspel te selecteren.")]
        public int BordspelId { get; set; }
        [Required(ErrorMessage = "Gelieve een persoon te selecteren.")]
        public int PersoonId { get; set; }
        [Required(ErrorMessage = "Gelieve een rol te selecteren.")]
        public int RolId { get; set; }
        public ICollection<Persoon> Personen { get; set; }
        public ICollection<Bordspel> Bordspellen { get; set; }
        public ICollection<Rol> Rollen { get; set; }
    }
}
