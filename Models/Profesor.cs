using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR30_2021_POP2022.Models
{
    public class Profesor : RegistrovaniKorisnik
    {
        private Skola skola;
        private List<string> jezici;
        private List<Cas> casovi;

        public Profesor(string ime, string prezime, string jmbg, EPol pol, Adresa adresa, string email, string lozinka, ETipRegKorisnika tipKorisnika, bool aktivan, Skola skola, List<string> jezici, List<Cas> casovi) : base(ime, prezime, jmbg, pol, adresa, email, lozinka, tipKorisnika, aktivan)
        {
            this.skola = skola;
            this.jezici = jezici;
            this.casovi = casovi;
        }

        public Profesor()
        {
            this.skola = new Skola();
            this.jezici = new List<string>();
            this.casovi = new List<Cas>();

        }

        public List<string> Jezici { get => jezici; set => jezici = value; }
        public Skola Skola { get => skola; set => skola = value; }
        public List<Cas> Casovi { get => casovi; set => casovi = value; }

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " JMBG: " + Jmbg +  " Email: " + Email + " Skola: " + Skola + " Jezici: " + Jezici;
               
        }

        public string ProfesorZaUpisUFajl()
        {
            return Ime + ";" + Prezime + ";" + Jmbg + ";" + Pol + ";" + Adresa.Id + ";" + Email + ";" + Lozinka + ";" + TipKorisnika + ";" + Skola.Id + ";" + Jezici + ";" + Casovi + ";" + Aktivan;
        }
      
    
    }
}
