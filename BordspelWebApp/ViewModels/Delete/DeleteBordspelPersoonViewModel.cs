using System.ComponentModel.DataAnnotations;

namespace BordspelWebApp.ViewModels.Delete
{
    public class DeleteBordspelPersoonViewModel
    {
        public int Id { get; set; }
        public int BordspelId { get; set; }
        public int PersoonId { get; set; }
        public int RolId { get; set; }
    }
}
