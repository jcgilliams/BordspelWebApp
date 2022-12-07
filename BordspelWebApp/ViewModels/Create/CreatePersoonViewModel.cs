using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Create
{
    public class CreatePersoonViewModel
    {
        [Required(ErrorMessage = "Gelieve een naam in te vullen aub.")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Gelieve een voornaam in te vullen aub.")]
        public string Voornaam { get; set; }
        public string Beschrijving { get; set; }
    }
}
