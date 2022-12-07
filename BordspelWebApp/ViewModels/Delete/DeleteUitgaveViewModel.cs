using BordspelWebApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Delete
{
    public class DeleteUitgaveViewModel
    {
        public int Id { get; set; }
        public int UitgeverijId { get; set; }
        public int BordspelId { get; set; }
        public string Taal { get; set; }
    }
}
