using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SR30_2021_POP2022.Models
{
    public class Skola
    {
        private int id;
        private string naziv;
        private Adresa adresa;
        private List<string> jezici;
        private bool obrisana;

        public Skola(int id, string naziv, Adresa adresa, List<string> jezici, bool obrisana)
        {
            this.id = id;
            this.naziv = naziv;
            this.adresa = adresa;
            this.jezici = jezici;
            this.obrisana = obrisana;
        }

        public Skola()
        {
            this.id = 0;
            this.naziv = "";
            this.adresa = new Adresa();
            this.jezici = new List<string>();
            this.obrisana = false;
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public List<string> Jezici { get => jezici; set => jezici = value; }
        public Adresa Adresa { get => adresa; set => adresa = value; }
        public bool Obrisana { get => obrisana; set => obrisana = value; }

        public override string ToString()
        {
            return "ID: " + Id + " Naziv: " + Naziv + " Adresa: " + Adresa + " Jezici: " + Jezici + " Obrisana: " + Obrisana;
        }

        public string SkolaZaUpisUFajl()
        {
            return Id + ";" + Naziv + ";" + Adresa.Id + ";" + Jezici + ";" + Obrisana;
        }
    }
}
