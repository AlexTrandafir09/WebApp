using WebApp.Models.Base;

namespace WebApp.Models.Liga
{
    public class Liga:BaseEntity
    {
        public string denumire { get; set; }

        public string presedinte {  get; set; }

        public int? esalon {  get; set; }

        public ICollection<Echipa_liga.Echipa_liga> echipe { get; set; }

        
    }
}
