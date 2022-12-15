using SR30_2021_POP2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for StudentiProzor.xaml
    /// </summary>
    public partial class StudentiProzor : Window
    {
        ICollectionView view;
     
        public StudentiProzor()
        {
            InitializeComponent();
          
            view = CollectionViewSource.GetDefaultView(Data.Studenti);
            view.Filter = Filter;
            dgStudenti.ItemsSource = view;
        }

        private bool Filter(object obj)
        {
            Student s = obj as Student;
            if (s.Aktivan)
            {
                return true;
            }
            return false;

        }




        private void miDodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student();
            DodajIzmeniStudentaProzor dodajIzmeniStudentaProzor = new DodajIzmeniStudentaProzor(s)
            {
                Title = "Dodaj"
            };
            dodajIzmeniStudentaProzor.ShowDialog();
            view.Refresh();

        }

        private void miIzmeniStudenta_Click(object sender, RoutedEventArgs e)
        {
            if(dgStudenti.SelectedItem == null)
            {
                MessageBox.Show("Korisnik nije selektovan!", "Greška");
            }
            else
            {
                Student s = (Student) dgStudenti.SelectedItem;

                Student studentKopija = new Student();
                studentKopija.Ime = s.Ime;
                studentKopija.Prezime = s.Prezime;
                studentKopija.Jmbg = s.Jmbg;
                studentKopija.Pol = s.Pol;

                studentKopija.Adresa.Id = s.Adresa.Id;
                studentKopija.Adresa.Ulica = s.Adresa.Ulica;
                studentKopija.Adresa.Broj = s.Adresa.Broj;
                studentKopija.Adresa.Grad = s.Adresa.Grad;
                studentKopija.Adresa.Drzava = s.Adresa.Drzava;

                studentKopija.Email = s.Email;
                studentKopija.Lozinka = s.Lozinka;
                studentKopija.TipKorisnika = s.TipKorisnika;
                studentKopija.Aktivan = s.Aktivan;
                studentKopija.RezervisaniCasovi = s.RezervisaniCasovi;

                DodajIzmeniStudentaProzor dodajIzmeniStudentaProzor = new DodajIzmeniStudentaProzor(s)
                {
                    Title = "Izmeni"
                };
                

                if ((bool)!dodajIzmeniStudentaProzor.ShowDialog())
                {
                    int index = Data.Studenti.ToList().FindIndex(so => so.Email.Equals(s.Email));                
                    Data.Studenti[index] = studentKopija;

                }
                view.Refresh();

            }
            

        }
        private void miObrisiStudenta_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudenti.SelectedItem == null)
            {
                MessageBox.Show("Korisnik nije selektovan!", "Greška");
            }
            else
            {

                Student s = (Student)dgStudenti.SelectedItem;
                    
                Data.ObrisiStudenta(s.Email);
                view.Refresh();

            }

        }

       
    }
}
