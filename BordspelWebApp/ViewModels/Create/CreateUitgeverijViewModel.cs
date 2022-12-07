using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Create
{
    public class CreateUitgeverijViewModel
    {
        [Required(ErrorMessage = "Gelieve een naam in te vullen aub.")]
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Gelieve een land in te vullen aub.")]
        public string Land { get; set; }
    }
}
