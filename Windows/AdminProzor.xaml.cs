using SR30_2021_POP2022.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminProzor.xaml
    /// </summary>
    public partial class AdminProzor : Window
    {
        public RegistrovaniKorisnik a;

        public AdminProzor(RegistrovaniKorisnik prijavljeniAdmin)
        {
            InitializeComponent();

            a = prijavljeniAdmin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentiProzor studentiProzor = new StudentiProzor();
            studentiProzor.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SkoleProzor skoleProzor = new SkoleProzor();
            skoleProzor.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProfesoriProzor profesoriProzor = new ProfesoriProzor();
            profesoriProzor.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CasoviProzor casoviProzor = new CasoviProzor();
            casoviProzor.Show();
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik adminKopija = new RegistrovaniKorisnik();
            adminKopija.Ime = a.Ime;
            adminKopija.Prezime = a.Prezime;
            adminKopija.Jmbg = a.Jmbg;
            adminKopija.Pol = a.Pol;

            adminKopija.Adresa.Id = a.Adresa.Id;
            adminKopija.Adresa.Ulica = a.Adresa.Ulica;
            adminKopija.Adresa.Broj = a.Adresa.Broj;
            adminKopija.Adresa.Grad = a.Adresa.Grad;
            adminKopija.Adresa.Drzava = a.Adresa.Drzava;

            adminKopija.Email = a.Email;
            adminKopija.Lozinka = a.Lozinka;
            adminKopija.TipKorisnika = a.TipKorisnika;
            adminKopija.Aktivan = a.Aktivan;         


            IzmeniAdmina izmeniAdmina = new IzmeniAdmina(a)
            {
                Title = "Izmeni"
            };
            izmeniAdmina.txtEmail.IsReadOnly = true;
            izmeniAdmina.txtJmbg.IsReadOnly = true;
            //izmeniAdmina.ShowDialog();

            if ((bool)!izmeniAdmina.ShowDialog())
            {
                int index = Data.Administratori.ToList().FindIndex(so => so.Email.Equals(a.Email));
                Data.Administratori[index] = adminKopija;
                a = adminKopija;

            }
            
        }
    }
}
