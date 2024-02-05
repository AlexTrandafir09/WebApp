namespace WebApp.Models.Echipa.EchipaDto
{
    public class EchipaResponseDto
    {
        public required Guid Id { get; set; }
        public required string denumire { get; set; }
        public required string antrenor { get; set; }
        public required string manager { get; set; }

        public int valoare { get; set; }

        public required Guid baza_id { get; set; }
        public required string denumire_baza { get; set; }

        public ICollection<string>? nume_jucatori { get; set; }

        public ICollection<string>? nume_ligi { get; set; }

    }
}
