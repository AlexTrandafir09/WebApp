namespace WebApp.Models.Baza_sportiva.BazaDto
{
    public class BazaRequestDto
    {
        public required string nume_baza { get; set; }

        public required string adresa { get; set; }

        public int capacitate { get; set; }

        public Guid? echipa_id { get; set; }

        public Echipa.Echipa? echipa { get; set; }
    }
}
