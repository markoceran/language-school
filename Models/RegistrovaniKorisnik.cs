using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SR30_2021_POP2022.Models
{
    public class RegistrovaniKorisnik : IDataErrorInfo
    {
        private string ime;
        private string prezime;
        private string jmbg;
        private EPol pol;
        private Adresa adresa;
        private string email;
        private string lozinka;
        private ETipRegKorisnika tipKorisnika;
        private bool aktivan;

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
        public Adresa Adresa { get => adresa; set => adresa = value; }
        public bool Aktivan { get => aktivan; set => aktivan = value; }
        public bool IsValid { get; set; }

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " JMBG: " + Jmbg + " Pol: " + Pol + " Adresa: " + Adresa + " Email: " + Email + " Lozinka: " + Lozinka + " Tip korisnika: " + TipKorisnika + " Aktivan: " + Aktivan;
        }

        public string KorisnikZaUpisUFajl()
        {
            return Ime + ";" + Prezime + ";" + Jmbg+ ";" + Pol + ";" + Adresa.Id  + ";" + Email + ";" + Lozinka + ";" +TipKorisnika + ";" + Aktivan;
        }



        public string Error
        {
            get
            {
                if (string.IsNullOrEmpty(Ime))
                {
                    return "Ime mora biti uneto!";
                }
                else if (string.IsNullOrEmpty(Prezime))
                {
                    return "Prezime mora biti uneto!";
                }
                else if (string.IsNullOrEmpty(Jmbg) || Jmbg.Length < 13 || Jmbg.Length > 13)
                {
                    return "JMBG mora biti unet i mora imati 13 cifara!";
                }
                else if (string.IsNullOrEmpty(Email) || !Email.Contains("@gmail.com"))
                {
                    return "Email mora biti unet i mora sadrzati @gmail.com!";
                }
                else if (string.IsNullOrEmpty(Lozinka))
                {
                    return "Lozinka mora biti uneta!";
                }
                else if (Data.Profesori.ToList().Find(so => so.Email.Equals(Email)) != null)
                {
                    return "Profesor vec postoji!";
                }
                else if (Data.Studenti.ToList().Find(so => so.Email.Equals(Email)) != null)
                {
                    return "Student vec postoji!";
                }              

                return "";
            }
        }

        public string this[string columnName]
        {

            get
            {
                IsValid = true;

                if (columnName == "Ime" && string.IsNullOrEmpty(Ime))
                {
                    IsValid = false;
                    return "Ime mora biti uneto!";
                }
                else if (columnName == "Prezime" && string.IsNullOrEmpty(Prezime))
                {
                    IsValid = false;
                    return "Prezime mora biti uneto!";
                }
                else if (columnName == "Jmbg" && string.IsNullOrEmpty(Jmbg) || Jmbg.Length < 13 || Jmbg.Length > 13)
                {
                    IsValid = false;
                    return "JMBG mora biti unet i mora imati 13 cifara!";
                }               
                else if (columnName == "Lozinka" && string.IsNullOrEmpty(Lozinka))
                {
                    IsValid = false;
                    return "Lozinka mora biti uneta!";
                }
                else if (columnName == "Email" && string.IsNullOrEmpty(Email) || !Email.Contains("@gmail.com"))
                {
                    IsValid = false;
                    return "Email mora biti unet i mora sadrzati @!";
                }
                

                return "";
            }
        }
    }
}
