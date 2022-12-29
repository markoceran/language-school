using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;



namespace SR30_2021_POP2022.Models
{
    
    public class Cas
    {
        private int id;
        private Profesor profesor;
        private DateTime datumOdrzavanja;
        private string vremePocetka;
        private int trajanje;
        private EStatusCasa status;
        private Student student;
        private bool obrisan;

        public Cas(int id, Profesor profesor, DateTime datumOdrzavanja, string vremePocetka, int trajanje, EStatusCasa status, Student student, bool obrisan)
        {
            this.id = id;
            this.profesor = profesor;
            this.datumOdrzavanja = datumOdrzavanja;
            this.vremePocetka = vremePocetka;
            this.trajanje = trajanje;
            this.status = status;
            this.student = student;
            this.Obrisan = obrisan;
        }

        public Cas()
        {
            this.id = 0;
            this.profesor = new Profesor();
            this.datumOdrzavanja = DateTime.Now;
            this.vremePocetka = "";
            this.trajanje = 0;
            this.status = EStatusCasa.SLOBODAN;
            this.student = new Student();
            this.Obrisan = false;

        }


        public int Id { get => id; set => id = value; }
        public DateTime DatumOdrzavanja { get => datumOdrzavanja; set => datumOdrzavanja = value; }
        public string VremePocetka { get => vremePocetka; set => vremePocetka = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }
        public EStatusCasa Status { get => status; set => status = value; }
        public Profesor Profesor { get => profesor; set => profesor = value; }
        public Student Student { get => student; set => student = value; }
        public bool Obrisan { get => obrisan; set => obrisan = value; }

        public override string ToString()
        {
            return " ID: " + Id  + " Profesor: " + Profesor + " Datum: " + DatumOdrzavanja + " Vreme: " + VremePocetka + " Trajanje: " + Trajanje + " Status: " + Status + " Student: " + Student + " Obrisan: " + Obrisan;
        }

        public string CasZaUpisUFajl()
        {
            return Id + ";" + Profesor.Email + ";" + DatumOdrzavanja+ ";" + VremePocetka  + ";" + Trajanje+ ";" + Status + ";" + Student.Email + ";" + Obrisan;
        }
    }
}
