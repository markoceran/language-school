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
    }
}
