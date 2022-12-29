using SR30_2021_POP2022.Models;
using System;
using System.Collections;
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

            //Vec zadani jezici

            listBoxJezici.Items.Add("engleski");
            listBoxJezici.Items.Add("nemacki");
            listBoxJezici.Items.Add("turski");
            listBoxJezici.Items.Add("ruski");        

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            /*if(listBoxJezici.SelectedItems.Count)
            {
                selektovanaSkola.IsValid = false;
                
            }  */

            
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

                    if (listBoxJezici.SelectedItems.Count > 0)
                    {
                        foreach (string str in listBoxJezici.SelectedItems)
                        {
                            selektovanaSkola.Jezici.Add(str);

                        }
                    }

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

                    selektovanaSkola.Jezici.Clear();

                    if (listBoxJezici.SelectedItems.Count > 0)
                    {
                        foreach (string str in listBoxJezici.SelectedItems)
                        {
                            selektovanaSkola.Jezici.Add(str);
                        }
                    }

                }


                //Data.SacuvajAdresu("adrese.txt");
                Data.SacuvajSkolu("skole.txt");
                this.DialogResult = true;
                this.Close();


            
                


        }
            

        private void btnDodajNoviJezik_Click(object sender, RoutedEventArgs e)
        {
           
            if (txtDodajNoviJezik.Text != "")
            {
                listBoxJezici.Items.Add(txtDodajNoviJezik.Text);
                txtDodajNoviJezik.Text = "";
            }
            
        }
    }
    
}
