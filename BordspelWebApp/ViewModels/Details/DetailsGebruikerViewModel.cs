using BordspelWebApp.Areas.Data;
using System.Collections.Generic;

namespace BordspelWebApp.ViewModels.Details
{
    public class DetailsGebruikerViewModel
    {
        public string Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string UserName { get; set; }
        public List<Gebruiker> Gebruikers { get; set; }
    }
}
