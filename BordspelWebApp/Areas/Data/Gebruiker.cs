using Microsoft.AspNetCore.Identity;

namespace BordspelWebApp.Areas.Data
{
    public class Gebruiker : IdentityUser
    {
        [PersonalData]
        public string Naam { get; set; }
    }
}
