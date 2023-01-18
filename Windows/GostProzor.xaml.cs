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
    /// Interaction logic for GostProzor.xaml
    /// </summary>
    public partial class GostProzor : Window
    {
        ICollectionView view;

        public GostProzor()
        {
            InitializeComponent();  

        }

        private void Pretraga_Click(object sender, RoutedEventArgs e)
        {
            tbPretraga.Text = "";
           
            view = CollectionViewSource.GetDefaultView(Data.Skole);
            view.Filter = Filter;
            dgPretraga.ItemsSource = view;
            dgPretraga.IsReadOnly = true;
            //view.Refresh();

        }


        private bool Filter(object obj)
        {
            Skola skola = (Skola)obj;
            if ((skola.Adresa.Drzava.Contains(tbMesto.Text) ||
                skola.Adresa.Grad.Contains(tbMesto.Text)) && skola.Jezici.Contains(tbJezik.Text) && skola.Obrisana == false)
            {
                foreach (Profesor p in Data.Profesori)
                {
                    if (p.Skola == skola && p.Skola != null)
                    {
                        skola.ListaProfesora.Add(p);

                    }

                }
                skola.ListaProfesora = skola.ListaProfesora.Distinct().ToList();
                return true;
            }
            return false;

        }

        private bool Filter2(object obj)
        {
            Skola skola = (Skola)obj;
            if ((skola.Naziv.Contains(tbPretraga.Text) || skola.Adresa.Drzava.Contains(tbPretraga.Text) ||
                skola.Adresa.Grad.Contains(tbPretraga.Text) || skola.Adresa.Ulica.Contains(tbPretraga.Text) ||
                skola.Jezici.Contains(tbPretraga.Text) || skola.ListaProfesora.Find(p => p.Ime.Contains(tbPretraga.Text)) != null ||
                skola.ListaProfesora.Find(p => p.Prezime.Contains(tbPretraga.Text)) != null ||
                skola.ListaProfesora.Find(p => p.Jezici.Contains(tbPretraga.Text)) != null ||
                skola.ListaProfesora.Find(p => p.Email.Contains(tbPretraga.Text)) != null ||
                skola.ListaProfesora.Find(p => p.Adresa.Grad.Contains(tbPretraga.Text)) != null ||
                skola.ListaProfesora.Find(p => p.Adresa.Drzava.Contains(tbPretraga.Text)) != null)  && skola.Obrisana == false)
            {
                foreach (Profesor p in Data.Profesori)
                {
                    if (p.Skola == skola && p.Skola != null)
                    {
                        skola.ListaProfesora.Add(p);

                    }

                }
                skola.ListaProfesora = skola.ListaProfesora.Distinct().ToList();
                return true;
            }
            return false;

        }

        private void tbPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view = CollectionViewSource.GetDefaultView(Data.Skole);
            view.Filter = Filter2;
            dgPretraga.ItemsSource = view;
            dgPretraga.IsReadOnly = true;

        }
    }
}
