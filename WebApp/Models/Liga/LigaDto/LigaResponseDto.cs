namespace WebApp.Models.Liga.LigaDto
{
    public class LigaResponseDto
    {
        public Guid Id { get; set; }
        public required string denumire { get; set; }

        public required string presedinte { get; set; }

        public int? esalon { get; set; }

        public ICollection<string>? echipe_participante { get; set; }
    }
}
