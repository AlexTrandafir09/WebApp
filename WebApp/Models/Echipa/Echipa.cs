using WebApp.Models.Base;
namespace WebApp.Models.Echipa
{
    public class Echipa : BaseEntity
    {
        public string denumire { get; set; }
        public string antrenor { get; set; }
        public string manager {  get; set; }

        public int valoare { get; set; }
    
    }
}
