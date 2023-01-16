using SR30_2021_POP2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SR30_2021_POP2022.Windows
{
    /// <summary>
    /// Interaction logic for PrijavaProzor.xaml
    /// </summary>
    public partial class PrijavaProzor : Window
    {
        public Profesor prijavljeniProfesor;
        public Student prijavljeniStudent;
        public RegistrovaniKorisnik prijavljeniAdmin;

        public PrijavaProzor()
        {
            InitializeComponent();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            
            if(tbEmail.Text != "" && tbEmail.Text.Contains("@gmail.com") && tbLozinka.Text != "")
            {
                foreach(Profesor profesor in Data.Profesori)
                {
                    if(profesor.Email == tbEmail.Text && profesor.Lozinka == tbLozinka.Text && profesor.Aktivan == true)
                    {
                        prijavljeniProfesor = profesor;
                        ProzorZaProfesora prozorZaProfesora = new ProzorZaProfesora(prijavljeniProfesor);
                        this.Hide();
                        prozorZaProfesora.Title = prijavljeniProfesor.Email;
                        prozorZaProfesora.Show();
                        

                    }
                    
                }

                foreach (Student student in Data.Studenti)
                {
                    if (student.Email == tbEmail.Text && student.Lozinka == tbLozinka.Text && student.Aktivan == true)
                    {
                        prijavljeniStudent = student;
                        ProzorZaStudenta prozorZaStudenta = new ProzorZaStudenta(prijavljeniStudent);
                        this.Hide();
                        prozorZaStudenta.Title = prijavljeniStudent.Email;
                        prozorZaStudenta.Show();

                    }

                }

                foreach (RegistrovaniKorisnik admin in Data.Administratori)
                {
                    if (admin.Email == tbEmail.Text && admin.Lozinka == tbLozinka.Text && admin.Aktivan == true)
                    {
                        prijavljeniAdmin = admin;
                        AdminProzor adminProzor = new AdminProzor(prijavljeniAdmin);
                        this.Hide();
                        adminProzor.Title = prijavljeniAdmin.Email;
                        adminProzor.Show();

                    }

                }

                if(prijavljeniAdmin == null && prijavljeniProfesor == null && prijavljeniStudent == null)
                {
                    MessageBox.Show("KORISNIK SA UNETIM PODACIMA NE POSTOJI!", "Nije moguce izvrsiti prijavu na sistem");
                }

            }
            else
            {
                MessageBox.Show("Morate uneti email i lozinku!", "Greska");
            }

        }
    }
}
