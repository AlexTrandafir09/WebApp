﻿using WebApp.Models.Base;
namespace WebApp.Models.Baza_sportiva
{
    public class Baza_sportiva : BaseEntity
    {
        public string nume_baza {  get; set; }

        public string adresa {  get; set; } 

        public int capacitate { get; set;}

        public Guid? echipa_id { get; set; }

        public Echipa.Echipa? echipa { get; set; }
    }
}
