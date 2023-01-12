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

            foreach (Skola s in Data.Skole)
            {
                cmbMesto.Items.Add(s.Adresa.Grad);

                foreach (string i in s.Jezici)
                {
                    Data.JeziciSvihSkola.Add(i);
                }
            }

            listBoxJezici.ItemsSource = Data.JeziciSvihSkola.Distinct();

        }

        private void Pretraga_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMesto.SelectedItem != null && listBoxJezici.SelectedItems.Count > 0)
            {
                view = CollectionViewSource.GetDefaultView(Data.Skole);
                view.Filter = Filter;
                dgPretraga.ItemsSource = view;
                dgPretraga.IsReadOnly = true;
                view.Refresh();
            }

        }

        private bool Filter(object obj)
        {
            
            Skola s = obj as Skola;

            foreach (string j in listBoxJezici.SelectedItems)
            {
                if (s.Adresa.Grad.Equals(cmbMesto.SelectedItem) && s.Jezici.Contains(j))
                {
                    foreach (Profesor p in Data.Profesori)
                    {
                        if (p.Skola == s && p.Skola != null)
                        {                         
                            s.ListaProfesora.Add(p);
                           
                        }
                            
                    }

                    s.ListaProfesora = s.ListaProfesora.Distinct().ToList();                  
                    return true;
                }

            }
            return false;

        }

    }
}
