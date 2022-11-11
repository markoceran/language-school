using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR30_2021_POP2022.Models
{
    class RegistrovaniKorisnik
    {
        private string ime;
        private string prezime;
        private string jmbg;
        private EPol pol;
        private Adresa adresa;
        private string email;
        private string lozinka;
        private TipRegKorisnika tipKorisnika;

        public RegistrovaniKorisnik(string ime, string prezime, string jmbg, EPol pol, Adresa adresa, string email, string lozinka, TipRegKorisnika tipKorisnika)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.pol = pol;
            this.adresa = adresa;
            this.email = email;
            this.lozinka = lozinka;
            this.tipKorisnika = tipKorisnika;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public EPol Pol { get => pol; set => pol = value; }
        public string Email { get => email; set => email = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public TipRegKorisnika TipKorisnika { get => tipKorisnika; set => tipKorisnika = value; }
        internal Adresa Adresa { get => adresa; set => adresa = value; }

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " JMBG: " + Jmbg + " Pol: " + Pol + " Adresa: " + Adresa + " Email: " + Email + " Lozinka: " + Lozinka + " Tip korisnika: " + TipKorisnika;
        }
    }
}
