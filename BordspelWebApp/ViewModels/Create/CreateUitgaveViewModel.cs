using BordspelWebApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Create
{
    public class CreateUitgaveViewModel
    {
        [Required(ErrorMessage = "Gelieve een uitgeverij te selecteren.")]
        public int UitgeverijId { get; set; }
        [Required(ErrorMessage = "Gelieve een bordspel te selecteren.")]
        public int BordspelId { get; set; }
        [Required(ErrorMessage = "Gelieve een taal in te vullen aub.")]
        public string Taal { get; set; }
        public ICollection<Uitgeverij> Uitgeverijen { get; set; }
        public ICollection<Bordspel> Bordspellen { get; set; }
    }
}
