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
    /// Interaction logic for DodajIzmeniSkoluProzor.xaml
    /// </summary>
    public partial class DodajIzmeniSkoluProzor : Window
    {
        private Skola selektovanaSkola;

        public DodajIzmeniSkoluProzor(Skola skola)
        {
            InitializeComponent();

            selektovanaSkola = skola;

            this.DataContext = skola;

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (this.Title.Equals("Dodaj"))
            {

                Adresa a = Data.Adrese.ToList().Find(k => k.Id.ToString().Contains(txtAdresa.Text));

                selektovanaSkola.Adresa = a;
            
                selektovanaSkola.Obrisana = false;
                Data.Skole.Add(selektovanaSkola);

            }

            Data.SacuvajSkolu("skole.txt");
            this.DialogResult = true;
            this.Close();
        }
    }
    
}
