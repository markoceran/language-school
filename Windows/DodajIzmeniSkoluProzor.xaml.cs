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

                if (!Data.Adrese.Count.Equals(0))
                {
                    selektovanaSkola.Adresa.Id = Data.Adrese.Last().Id + 1;

                }
                else
                {
                    selektovanaSkola.Adresa.Id = 1;
                }
            
                selektovanaSkola.Obrisana = false;
                Data.Adrese.Add(selektovanaSkola.Adresa);
                Data.SacuvajAdresu("adrese.txt");
                Data.Skole.Add(selektovanaSkola);

            }

            //Zbog nekonzistentnosti upisa u fajl (kada se ide: izmena adrese -> odustani -> izmena adrese -> odustani -> izmena adrese -> sacuvaj)
            if (this.Title.Equals("Izmeni"))
            {

                Adresa ad = Data.Adrese.ToList().Find(so => so.Id.Equals(selektovanaSkola.Adresa.Id));
                ad.Drzava = txtDrzava.Text;
                ad.Ulica = txtUlica.Text;
                ad.Broj = int.Parse(txtBroj.Text);
                ad.Grad = txtGrad.Text;
                Data.SacuvajAdresu("adrese.txt");

            }


            //Data.SacuvajAdresu("adrese.txt");
            Data.SacuvajSkolu("skole.txt");
            this.DialogResult = true;
            this.Close();
        }
    }
    
}
