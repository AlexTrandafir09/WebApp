using WebApp.Models.Base;

namespace WebApp.Models.Echipa_liga
{
    public class Echipa_liga : BaseEntity
    {
        public Guid echipa_id {  get; set; }
        public Guid liga_id { get; set; }

        public required Liga.Liga liga { get; set; }

        public required Echipa.Echipa echipa {  get; set; } 

        public int esalon { get; set; } 

    }
}
