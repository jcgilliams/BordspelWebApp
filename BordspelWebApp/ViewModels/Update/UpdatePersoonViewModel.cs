using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Update
{
    public class UpdatePersoonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gelieve een naam in te vullen aub.")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Gelieve een voornaam in te vullen aub.")]
        public string Voornaam { get; set; }
        public string Beschrijving { get; set; }
    }
}
