using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SR30_2021_POP2022.Models
{
    class Skola
    {
        private int id;
        private string naziv;
        private Adresa adresa;
        private List<string> jezici = new List<string>();

        public Skola(int id, string naziv, Adresa adresa, List<string> jezici)
        {
            this.id = id;
            this.naziv = naziv;
            this.adresa = adresa;
            this.jezici = jezici;
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public List<string> Jezici { get => jezici; set => jezici = value; }
        internal Adresa Adresa { get => adresa; set => adresa = value; }

        public override string ToString()
        {
            return "ID: " + Id + "Naziv: " + Naziv + " Adresa: " + Adresa + " Jezici: " + Jezici;
        }
    }
}
