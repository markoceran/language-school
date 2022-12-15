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
    /// Interaction logic for SkoleProzor.xaml
    /// </summary>
    public partial class SkoleProzor : Window
    {
        ICollectionView view;

        public SkoleProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Data.Skole);
            view.Filter = Filter;
            dgSkole.ItemsSource = view;
        }

        private bool Filter(object obj)
        {
            Skola sk = obj as Skola;
            if (!sk.Obrisana)
            {
                return true;
            }
            return false;

        }

        private void miDodajSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola sk = new Skola();
            DodajIzmeniSkoluProzor dodajIzmeniSkoluProzor = new DodajIzmeniSkoluProzor(sk)
            {
                Title = "Dodaj"
            };
            dodajIzmeniSkoluProzor.ShowDialog();
            view.Refresh();

        }

        private void miIzmeniSkolu_Click(object sender, RoutedEventArgs e)
        {
            if (dgSkole.SelectedItem == null)
            {
                MessageBox.Show("Skola nije selektovana!", "Greška");
            }
            else
            {
                Skola sk = (Skola)dgSkole.SelectedItem;

                Skola skolaKopija = new Skola();
                skolaKopija.Id = sk.Id;
                skolaKopija.Naziv = sk.Naziv;

                skolaKopija.Adresa.Id = sk.Adresa.Id;
                skolaKopija.Adresa.Ulica = sk.Adresa.Ulica;
                skolaKopija.Adresa.Broj = sk.Adresa.Broj;
                skolaKopija.Adresa.Grad = sk.Adresa.Grad;
                skolaKopija.Adresa.Drzava = sk.Adresa.Drzava;

                skolaKopija.Jezici = sk.Jezici;
                skolaKopija.Obrisana = sk.Obrisana;


                DodajIzmeniSkoluProzor dodajIzmeniSkoluProzor = new DodajIzmeniSkoluProzor(sk)
                {
                    Title = "Izmeni"
                    
                };
                dodajIzmeniSkoluProzor.txtId.IsEnabled = false;
                

                if ((bool)!dodajIzmeniSkoluProzor.ShowDialog())
                {
                    int index = Data.Skole.ToList().FindIndex(s => s.Id.Equals(sk.Id));
                    Data.Skole[index] = skolaKopija;
                }
                view.Refresh();

            }
        }
        private void miObrisiSkolu_Click(object sender, RoutedEventArgs e)
        {
            if (dgSkole.SelectedItem == null)
            {
                MessageBox.Show("Skola nije selektovana!", "Greška");
            }
            else
            {

                Skola s = (Skola)dgSkole.SelectedItem;

                Data.ObrisiSkolu(s.Id);
                view.Refresh();

            }
        }
    }
}
