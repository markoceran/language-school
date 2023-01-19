using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SR30_2021_POP2022.Models
{
    public class Skola
    {
        private int id;
        private string naziv;
        private Adresa adresa;
        private List<string> jezici;
        private bool obrisana;
        private List<Profesor> listaProfesora;

        public Skola(int id, string naziv, Adresa adresa, List<string> jezici, bool obrisana, List<Profesor> listaProfesora)
        {
            this.id = id;
            this.naziv = naziv;
            this.adresa = adresa;
            this.jezici = jezici;
            this.obrisana = obrisana;
            this.listaProfesora = listaProfesora;
        }

        public Skola()
        {
            this.id = 0;
            this.naziv = "";
            this.adresa = new Adresa();
            this.jezici = new List<string>();
            this.obrisana = false;
            this.listaProfesora = new List<Profesor>();
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public List<string> Jezici { get => jezici; set => jezici = value; }
        public Adresa Adresa { get => adresa; set => adresa = value; }
        public bool Obrisana { get => obrisana; set => obrisana = value; }
        public bool IsValid { get; set; }
        public List<Profesor> ListaProfesora { get => listaProfesora; set => listaProfesora = value; }



        public override string ToString()
        {  
            return " Naziv: " + Naziv + " Adresa: " + Adresa;
        }

        /*public string SkolaZaUpisUFajl()
        { 
            string i = "";

            foreach(string j in Jezici)
            {
                i = i + j + ",";
                
            }
            i = i.Substring(0, i.Length - 1);

            return Id + ";" + Naziv + ";" + Adresa.Id + ";" + i + ";" + Obrisana;
        }*/




        public string Error
        {
            get
            {
                if (string.IsNullOrEmpty(Naziv))
                {
                    return "Naziv mora biti unet!";
                }
                else if (string.IsNullOrEmpty(Adresa.Drzava) || string.IsNullOrEmpty(Adresa.Grad) || string.IsNullOrEmpty(Adresa.Ulica) || Adresa.Broj == 0 || Adresa.Broj.ToString() == "")
                {
                    return "Adresa mora biti uneta!";
                }



                return "";
            }
        }


        public string this[string columnName]
        {

            get
            {
                IsValid = true;

                if (columnName == "Naziv" && string.IsNullOrEmpty(Naziv))
                {
                    IsValid = false;
                    return "Naziv mora biti unet!";
                }
                else if (string.IsNullOrEmpty(Adresa.Drzava) || string.IsNullOrEmpty(Adresa.Grad) || string.IsNullOrEmpty(Adresa.Ulica) || Adresa.Broj == 0 || Adresa.Broj.ToString() == "")
                {
                    IsValid = false;
                    return "Adresa mora biti uneta!";
                }



                return "";
            }
        }
    }
}
