namespace WebApp.Models.Echipa_liga.Echipa_ligaDto
{
    public class Echipa_ligaResponseDto
    {
        public Guid Id {get; set;}
        public string denumire_liga {  get; set; }

        public string denumire_echipa { get; set; }
        public int esalon { get; set; }
    }
}
