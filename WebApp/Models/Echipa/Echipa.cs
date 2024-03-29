﻿using WebApp.Models.Base;
namespace WebApp.Models.Echipa
{
    public class Echipa : BaseEntity
    {
        public required string denumire { get; set; }
        public required string antrenor { get; set; }
        public required string manager {  get; set; }

        public int? valoare { get; set; }

        public ICollection<Jucator.Jucator>? jucatori { get; set; }

        public Baza_sportiva.Baza_sportiva? baza {  get; set; }

        public ICollection<Echipa_liga.Echipa_liga>? echipe_ligi { get; set; }

    
    }
}
