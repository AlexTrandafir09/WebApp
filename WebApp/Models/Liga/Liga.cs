using WebApp.Models.Base;

namespace WebApp.Models.Liga
{
    public class Liga:BaseEntity
    {
        public required string denumire { get; set; }

        public required string presedinte {  get; set; }

        public int? esalon {  get; set; }

        public ICollection<Echipa_liga.Echipa_liga> echipe_ligi { get; set; }

        
    }
}
