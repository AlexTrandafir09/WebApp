namespace WebApp.Models.Liga.LigaDto
{
    public class LigaRequestDto
    {
        public required string denumire { get; set; }

        public required string presedinte { get; set; }

        public int? esalon { get; set; }

        public ICollection<Echipa_liga.Echipa_liga> echipe_ligi { get; set; }
    }
}
