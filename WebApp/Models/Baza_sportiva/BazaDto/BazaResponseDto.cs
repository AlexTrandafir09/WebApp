namespace WebApp.Models.Baza_sportiva.BazaDto
{
    public class BazaResponseDto
    {
        public required string nume_baza { get; set; }

        public int capacitate { get; set; }

        public Guid? echipa_id { get; set; }
        public Echipa.Echipa? echipa { get; set; }
    }
}
