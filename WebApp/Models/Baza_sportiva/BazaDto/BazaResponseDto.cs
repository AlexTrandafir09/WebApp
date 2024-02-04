namespace WebApp.Models.Baza_sportiva.BazaDto
{
    public class BazaResponseDto
    {
        public required Guid Id { get; set; }
        public required string nume_baza { get; set; }

        public int capacitate { get; set; }

        public Guid? echipa_id { get; set; }
        public string nume_echipa { get; set; }
    }
}
