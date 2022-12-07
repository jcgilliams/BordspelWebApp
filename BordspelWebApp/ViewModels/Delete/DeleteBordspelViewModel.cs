namespace BordspelWebApp.ViewModels.Delete
{
    public class DeleteBordspelViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Jaar { get; set; }
        public string Beschrijving { get; set; }
        public int? MinAantalSpelers { get; set; }
        public int? MaxAantalSpelers { get; set; }
        public int? MinSpeeltijd { get; set; }
        public int? MaxSpeeltijd { get; set; }
        public int? Leeftijd { get; set; }
        public string Afbeelding { get; set; }

    }
}
