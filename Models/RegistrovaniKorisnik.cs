using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR30_2021_POP2022.Models
{
    public class RegistrovaniKorisnik
    {
        private string ime;
        private string prezime;
        private string jmbg;
        private EPol pol;
        private Adresa adresa;
        private string email;
        private string lozinka;
        private ETipRegKorisnika tipKorisnika;
        bool aktivan;

        public RegistrovaniKorisnik(string ime, string prezime, string jmbg, EPol pol, Adresa adresa, string email, string lozinka, ETipRegKorisnika tipKorisnika, bool aktivan)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.pol = pol;
            this.adresa = adresa;
            this.email = email;
            this.lozinka = lozinka;
            this.tipKorisnika = tipKorisnika;
            this.aktivan = aktivan;
        }
        
        public RegistrovaniKorisnik()
        {
            this.ime = "";
            this.prezime = "";
            this.jmbg = "";
            this.pol = EPol.MUSKI;
            this.adresa = new Adresa();
            this.email = "";
            this.lozinka = "";
            this.tipKorisnika = ETipRegKorisnika.ADMINISTRATOR;
            this.aktivan = false;

        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public EPol Pol { get => pol; set => pol = value; }
        public string Email { get => email; set => email = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public ETipRegKorisnika TipKorisnika { get => tipKorisnika; set => tipKorisnika = value; }
        internal Adresa Adresa { get => adresa; set => adresa = value; }
        public bool Aktivan { get => aktivan; set => aktivan = value; }

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " JMBG: " + Jmbg + " Pol: " + Pol + " Adresa: " + Adresa + " Email: " + Email + " Lozinka: " + Lozinka + " Tip korisnika: " + TipKorisnika + " Aktivan: " + Aktivan;
        }

        public string KorisnikZaUpisUFajl()
        {
            return Ime + ";" + Prezime + ";" + Jmbg+ ";" + Pol + ";" + Adresa.Id  + ";" + Email + ";" + Lozinka + ";" +TipKorisnika + ";" + Aktivan;
        }
    }
}
