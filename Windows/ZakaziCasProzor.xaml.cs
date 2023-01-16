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
    /// Interaction logic for ZakaziCasProzor.xaml
    /// </summary>
    public partial class ZakaziCasProzor : Window
    {
        ICollectionView view;
        Student s;

        public ZakaziCasProzor(Student prijavljeniStudent)
        {
            InitializeComponent();
            s = prijavljeniStudent;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            view = CollectionViewSource.GetDefaultView(Data.Casovi);
            view.Filter = Filter;
            //view.Refresh();
            dgCasovi.ItemsSource = view;
            dgCasovi.IsReadOnly = true;

        }

        private bool Filter(object obj)
        {
            Cas cas = (Cas)obj;
            if ((cas.Profesor.Ime.Contains(tbProfesor.Text) || cas.Profesor.Prezime.Contains(tbProfesor.Text) ||
                cas.Profesor.Adresa.Grad.Contains(tbProfesor.Text) || cas.Profesor.Adresa.Drzava.Contains(tbProfesor.Text) ||
                cas.Profesor.Email.Contains(tbProfesor.Text) || cas.Profesor.Jezici.Contains(tbProfesor.Text)) && cas.Status == EStatusCasa.SLOBODAN && cas.Obrisan == false)
            {
                return true;
            }
            return false;
            
        }

        private void miZakaziCas_Click(object sender, RoutedEventArgs e)
        {
            if (dgCasovi.SelectedItem == null)
            {
                MessageBox.Show("Čas nije selektovan!", "Greška");
            }
            else
            {
                Cas cas = (Cas)dgCasovi.SelectedItem;
                
                cas.Status = EStatusCasa.REZERVISAN;
                cas.Student = s;
                s.RezervisaniCasovi.Add(cas);
                Data.IzmeniCas(cas);
                view.Refresh();

                MessageBox.Show("Čas je uspešno zakazan!", "");
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
