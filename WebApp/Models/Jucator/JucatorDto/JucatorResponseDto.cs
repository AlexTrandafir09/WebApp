namespace WebApp.Models.Jucator.JucatorDto
{
    public class JucatorResponseDto
    {
        public required string nume { get; set; }
        public required string prenume { get; set; }

        public int numar_tricou { get; set; }

        public DateTime data_nasterii { get; set; }

        public string? denumire_echipa { get; set; }
    }
}
