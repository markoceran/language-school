using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SR30_2021_POP2022.Models
{
    class Cas
    {
        private int id;
        private Profesor profesor;
        private DateTime datumOdrzavanja;
        private string vremePocetka;
        private int trajanje;
        private StatusCasa status;
        private Student student;

        public Cas(int id, Profesor profesor, DateTime datumOdrzavanja, string vremePocetka, int trajanje, StatusCasa status, Student student)
        {
            this.id = id;
            this.profesor = profesor;
            this.datumOdrzavanja = datumOdrzavanja;
            this.vremePocetka = vremePocetka;
            this.trajanje = trajanje;
            this.status = status;
            this.student = student;
        }

        public int Id { get => id; set => id = value; }
        public DateTime DatumOdrzavanja { get => datumOdrzavanja; set => datumOdrzavanja = value; }
        public string VremePocetka { get => vremePocetka; set => vremePocetka = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }
        public StatusCasa Status { get => status; set => status = value; }
        internal Profesor Profesor { get => profesor; set => profesor = value; }
        internal Student Student { get => student; set => student = value; }

        public override string ToString()
        {
            return " ID: " + Id  + " Profesor: " + Profesor + " Datum: " + DatumOdrzavanja + " Vreme: " + VremePocetka + "Trajanje: " + Trajanje + "Status: " + Status + "Student: " + Student;
        }
    }
}
