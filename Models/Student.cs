using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR30_2021_POP2022.Models
{
    public class Student:RegistrovaniKorisnik
    {
        private List<Cas> rezervisaniCasovi;


        public List<Cas> RezervisaniCasovi { get => rezervisaniCasovi; set => rezervisaniCasovi = value; }

        public Student(string ime, string prezime, string jmbg, EPol pol, Adresa adresa, string email, string lozinka, ETipRegKorisnika tipKorisnika, bool aktivan, List<Cas> rezervisaniCasovi) : base(ime, prezime, jmbg, pol, adresa, email, lozinka, tipKorisnika, aktivan)
        {
            this.rezervisaniCasovi = rezervisaniCasovi;
        }

        public Student()
        {
            this.rezervisaniCasovi = new List<Cas>();
        }

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime  + " Email: " + Email + " Grad: " + Adresa.Grad;
        }

        public string StudentZaUpisUFajl()
        {
            return Ime + ";" + Prezime + ";" + Jmbg + ";" + Pol + ";" + Adresa.Id + ";" + Email + ";" + Lozinka + ";" + TipKorisnika + ";" + RezervisaniCasovi + ";" + Aktivan;
        }
    }
}
