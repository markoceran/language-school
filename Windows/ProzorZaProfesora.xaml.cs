using SR30_2021_POP2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
    /// Interaction logic for ProzorZaProfesora.xaml
    /// </summary>
    public partial class ProzorZaProfesora : Window
    {
        ICollectionView view;
        public Profesor p;

        public ProzorZaProfesora(Profesor prijavljeniProfesor)
        {
            InitializeComponent();

            p = prijavljeniProfesor;

            view = CollectionViewSource.GetDefaultView(prijavljeniProfesor.Casovi);
            view.Filter = Filter2;
            dgCasovi.ItemsSource = view;
            dgCasovi.IsReadOnly = true;
        }

        private void Button_Click_Pretrazi(object sender, RoutedEventArgs e)
        {
            if(datePickerDatum.SelectedDate != null)
            { 
                view.Filter = Filter;
                view.Refresh();

            }
           
        }

        private bool Filter(object obj)
        {
            Cas cas = (Cas)obj;
            if(cas.DatumOdrzavanja == datePickerDatum.SelectedDate && cas.Obrisan == false)
            {
                return true;
            }
            return false;
        }

        private bool Filter2(object obj)
        {
            Cas c = obj as Cas;
            if (c.Obrisan)
            {
                return false;
            }
            return true;
        }

        private void Button_Click_SviCasovi(object sender, RoutedEventArgs e)
        {
            view.Filter = null;
            view.Filter = Filter2;
            view.Refresh();
        }


        private void miDodajCas_Click(object sender, RoutedEventArgs e)
        {
            Cas c = new Cas();
            c.Profesor = p;
            c.Student = new Student();
            DodajIzmeniCasProzor dodajIzmeniCasProzor = new DodajIzmeniCasProzor(c)
            {
                Title = "Dodaj"
            };
            dodajIzmeniCasProzor.cmbProfesor.SelectedItem = p;
            dodajIzmeniCasProzor.cmbProfesor.IsEnabled = false;
            dodajIzmeniCasProzor.cmbStudent.IsEnabled = false;
            dodajIzmeniCasProzor.cmbStatus.IsEnabled = false;
            dodajIzmeniCasProzor.ShowDialog();
            view.Refresh();
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
                if(c.Status == EStatusCasa.SLOBODAN)
                {               
                    Data.ObrisiCas(c.Id);
                    view.Refresh();

                }
                else
                {
                    MessageBox.Show("Rezervisane časove nije moguće obrisati!", "");
                }


            }
        }
    }
}
