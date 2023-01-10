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
    /// Interaction logic for ProfesoriProzor.xaml
    /// </summary>
    public partial class ProfesoriProzor : Window
    {
        ICollectionView view;

        public ProfesoriProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Data.Profesori);
            view.Filter = Filter;
            dgProfesori.ItemsSource = view;
            dgProfesori.IsReadOnly = true;
           

        }

        private bool Filter(object obj)
        {
            Profesor p = obj as Profesor;
            if (p.Aktivan)
            {
                return true;
            }
            return false;

        }

        private void miDodajProfesora_Click(object sender, RoutedEventArgs e)
        {
            Profesor p = new Profesor();
            DodajIzmeniProfesoraProzor dodajIzmeniProfesoraProzor = new DodajIzmeniProfesoraProzor(p)
            {
                Title = "Dodaj"
            };                   
            dodajIzmeniProfesoraProzor.ShowDialog();
            view.Refresh();
        }

        private void miIzmeniProfesora_Click(object sender, RoutedEventArgs e)
        {
            if (dgProfesori.SelectedItem == null)
            {
                MessageBox.Show("Korisnik nije selektovan!", "Greška");
            }
            else
            {
                Profesor p = (Profesor)dgProfesori.SelectedItem;

                Profesor profesorKopija = new Profesor();
                profesorKopija.Ime = p.Ime;
                profesorKopija.Prezime = p.Prezime;
                profesorKopija.Jmbg = p.Jmbg;
                profesorKopija.Pol = p.Pol;

                profesorKopija.Adresa.Id = p.Adresa.Id;
                profesorKopija.Adresa.Ulica = p.Adresa.Ulica;
                profesorKopija.Adresa.Broj = p.Adresa.Broj;
                profesorKopija.Adresa.Grad = p.Adresa.Grad;
                profesorKopija.Adresa.Drzava = p.Adresa.Drzava;

                profesorKopija.Email = p.Email;
                profesorKopija.Lozinka = p.Lozinka;
                profesorKopija.TipKorisnika = p.TipKorisnika;
                profesorKopija.Aktivan = p.Aktivan;

                profesorKopija.Skola = p.Skola;
                profesorKopija.Jezici = p.Jezici;
                profesorKopija.Casovi = p.Casovi;

                DodajIzmeniProfesoraProzor dodajIzmeniProfesoraProzor = new DodajIzmeniProfesoraProzor(p)
                {
                    Title = "Izmeni"
                };
                dodajIzmeniProfesoraProzor.txtEmail.IsReadOnly = true;

                if ((bool)!dodajIzmeniProfesoraProzor.ShowDialog())
                {
                    int index = Data.Profesori.ToList().FindIndex(po => po.Email.Equals(p.Email));
                    Data.Profesori[index] = profesorKopija;
                }
                view.Refresh();

            }

        }
        private void miObrisiProfesora_Click(object sender, RoutedEventArgs e)
        {
            if (dgProfesori.SelectedItem == null)
            {
                MessageBox.Show("Korisnik nije selektovan!", "Greška");
            }
            else
            {

                Profesor p = (Profesor)dgProfesori.SelectedItem;

                Data.ObrisiProfesora(p.Email);
                view.Refresh();

            }
        }
    }
}
