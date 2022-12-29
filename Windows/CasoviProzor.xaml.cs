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
    /// Interaction logic for CasoviProzor.xaml
    /// </summary>
    public partial class CasoviProzor : Window
    {

        ICollectionView view;

        public CasoviProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Data.Casovi);
            view.Filter = Filter;
            dgCasovi.ItemsSource = view;
            dgCasovi.IsReadOnly = true;
              
        }

        private bool Filter(object obj)
        {
            Cas c = obj as Cas;
            if (c.Obrisan)
            {
                return false;
            }
            return true;

        }

        private void miDodajCas_Click(object sender, RoutedEventArgs e)
        {
            Cas c = new Cas();
            DodajIzmeniCasProzor dodajIzmeniCasProzor = new DodajIzmeniCasProzor(c)
            {
                Title = "Dodaj"
            };

            
            dodajIzmeniCasProzor.cmbStatus.IsEnabled = false;
            dodajIzmeniCasProzor.ShowDialog();
            view.Refresh();

        }

        private void miIzmeniCas_Click(object sender, RoutedEventArgs e)
        {
            if (dgCasovi.SelectedItem == null)
            {
                MessageBox.Show("Čas nije selektovan!", "Greška");
            }
            else
            {
                Cas c = (Cas)dgCasovi.SelectedItem;

                Cas casKopija = new Cas();
                casKopija.Id = c.Id;
                casKopija.DatumOdrzavanja = c.DatumOdrzavanja;
                casKopija.Trajanje = c.Trajanje;
                casKopija.VremePocetka = c.VremePocetka;
                casKopija.Status = c.Status;
                casKopija.Profesor = c.Profesor;
                casKopija.Student = c.Student;


                DodajIzmeniCasProzor dodajIzmeniCasProzor = new DodajIzmeniCasProzor(c)
                {
                    Title = "Izmeni"
                };
                dodajIzmeniCasProzor.txtId.IsEnabled = false;



                if ((bool)!dodajIzmeniCasProzor.ShowDialog())
                {
                    int index = Data.Casovi.ToList().FindIndex(ca => ca.Id.Equals(c.Id));      
                    Data.Casovi[index] = casKopija;
                    
                }
                view.Refresh();

            }

        }
        private void miObrisiCas_Click(object sender, RoutedEventArgs e)
        {
            if (dgCasovi.SelectedItem == null)
            {
                MessageBox.Show("Čas nije selektovan!", "Greška");
            }
            else
            {

                Cas c = (Cas)dgCasovi.SelectedItem;

                Data.ObrisiCas(c.Id);
                view.Refresh();

            }

        }
    }
}
