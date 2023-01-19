using SR30_2021_POP2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for ProzorZaStudenta.xaml
    /// </summary>
    public partial class ProzorZaStudenta : Window
    {
        ICollectionView view;
        public Student s;

        public ProzorZaStudenta(Student prijavljeniStudent)
        {
            InitializeComponent();

            s = prijavljeniStudent;

            view = CollectionViewSource.GetDefaultView(s.RezervisaniCasovi);
            view.Filter = Filter;
            dgCasovi.ItemsSource = view;
            dgCasovi.IsReadOnly = true;
        }

        private bool Filter(object obj)
        {
            Cas c = (Cas)obj;
            if(c.Obrisan == false)
            {
                return true;
            }
            return false;
        }

        private void miOtkaziRezervisaniCas_Click(object sender, RoutedEventArgs e)
        {
            if (dgCasovi.SelectedItem == null)
            {
                MessageBox.Show("Čas nije selektovan!", "Greška");
            }
            else
            {

                Cas c = (Cas)dgCasovi.SelectedItem;
                if (c.Status == EStatusCasa.REZERVISAN)
                {
                    c.Status = EStatusCasa.SLOBODAN;
                    c.Student = new Student();
                    s.RezervisaniCasovi.Remove(c);
                    Data.IzmeniCas(c);
                    view.Refresh();

                }              

            }
        }

        private void miZakaziCas_Click(object sender, RoutedEventArgs e)
        {
            ZakaziCasProzor zakaziCasProzor = new ZakaziCasProzor(s);
            zakaziCasProzor.ShowDialog();
            view.Refresh();
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
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
            dodajIzmeniStudentaProzor.txtEmail.IsReadOnly = true;
            dodajIzmeniStudentaProzor.txtJmbg.IsReadOnly = true;

            if ((bool)!dodajIzmeniStudentaProzor.ShowDialog())
            {
                int index = Data.Studenti.ToList().FindIndex(so => so.Email.Equals(s.Email));
                Data.Studenti[index] = studentKopija;
                s = studentKopija;

            }
        }


        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            PrijavaProzor prijava = new PrijavaProzor();
            prijava.Show();
            this.Close();
        }
    }
}
