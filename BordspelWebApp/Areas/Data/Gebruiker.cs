using BordspelWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BordspelWebApp.Areas.Data
{
    public class Gebruiker : IdentityUser
    {
        [PersonalData]
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public ICollection<Collectie> Collecties { get; set; }
    }
}
