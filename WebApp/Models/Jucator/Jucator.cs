using WebApp.Models.Base;

namespace WebApp.Models.Jucator
{
    public class Jucator:BaseEntity
    {
        public string nume {  get; set; }
        public string prenume {get; set; }

        public int numar_tricou { get; set; }

        public DateTime data_nasterii { get; set; }

        public Guid? echipa_id { get; set; } 
        public Echipa.Echipa? echipa { get; set; }
    }
}
