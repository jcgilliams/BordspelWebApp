using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Update
{
    public class UpdateUitgeverijViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gelieve een naam in te vullen aub.")]
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Gelieve een land in te vullen aub.")]
        public string Land { get; set; }
    }
}
