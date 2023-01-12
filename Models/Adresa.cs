using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR30_2021_POP2022.Models
{
    public class Adresa
    {
        private int id;
        private string ulica;
        private int broj;
        private string grad;
        private string drzava;

        public Adresa(int id, string ulica, int broj, string grad, string drzava)
        {
            this.id = id;
            this.ulica = ulica;
            this.broj = broj;
            this.grad = grad;
            this.drzava = drzava;
        }

        public Adresa()
        {
            this.id = 0;
            this.ulica = "";
            this.broj = 0;
            this.grad = "";
            this.drzava = "";
        }

        public int Id { get => id; set => id = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public int Broj { get => broj; set => broj = value; }
        public string Grad { get => grad; set => grad = value; }
        public string Drzava { get => drzava; set => drzava = value; }


        public override string ToString()
        {
            return " Ulica: " + Ulica + " Broj: " + Broj + " Grad: " + Grad + " Drzava: " + Drzava;
        }

        public string AdresaZaUpisUFajl()
        {
            return Id + ";" + Ulica + ";" + Broj + ";" + Grad + ";" + Drzava ;
        }

    }
}
