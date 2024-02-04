namespace WebApp.Models.Echipa_liga
{
    public class Echipa_liga
    {
        public int echipa_id {  get; set; }
        public int liga_id { get; set; }

        public Liga.Liga liga { get; set; }

        public Echipa.Echipa echipa {  get; set; } 

    }
}
