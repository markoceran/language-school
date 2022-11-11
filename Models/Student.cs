using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR30_2021_POP2022.Models
{
    class Student:RegistrovaniKorisnik
    {
        private List<Cas> rezervisaniCasovi = new List<Cas>();

        public Student(string ime, string prezime, string jmbg, EPol pol, Adresa adresa, string email, string lozinka, TipRegKorisnika tipKorisnika, List<Cas> rezervisaniCasovi) : base(ime, prezime, jmbg, pol, adresa, email, lozinka, tipKorisnika)
        {
            this.rezervisaniCasovi = rezervisaniCasovi;
        }

        internal List<Cas> RezervisaniCasovi { get => rezervisaniCasovi; set => rezervisaniCasovi = value; }

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " JMBG: " + Jmbg + " Pol: " + Pol + " Adresa: " + Adresa + " Email: " + Email + " Lozinka: " + Lozinka + " Tip korisnika: " + TipKorisnika
                + "Rezervisani casovi: " + RezervisaniCasovi;
        }
    }
}
