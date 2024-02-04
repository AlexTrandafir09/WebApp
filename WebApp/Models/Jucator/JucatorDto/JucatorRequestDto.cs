namespace WebApp.Models.Jucator.JucatorDto
{
    public class JucatorRequestDto
    {
        public required string nume { get; set; }
        public required string prenume { get; set; }

        public int numar_tricou { get; set; }

        public DateTime data_nasterii { get; set; }

        public Guid? echipa_id { get; set; }
        public Echipa.Echipa? echipa { get; set; }
    }
}
