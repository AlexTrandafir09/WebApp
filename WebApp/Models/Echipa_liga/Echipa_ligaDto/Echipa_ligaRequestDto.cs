namespace WebApp.Models.Echipa_liga.Echipa_ligaDto
{
    public class Echipa_ligaRequestDto
    {
        public Guid echipa_id { get; set; }
        public Guid liga_id { get; set; }

        public Liga.Liga liga { get; set; }

        public Echipa.Echipa echipa { get; set; }

        public int esalon { get; set; }
    }
}
