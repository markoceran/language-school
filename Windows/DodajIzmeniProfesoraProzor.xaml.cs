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
    /// Interaction logic for DodajIzmeniProfesoraProzor.xaml
    /// </summary>
    public partial class DodajIzmeniProfesoraProzor : Window
    {
        private Profesor selektovaniProfesor;

        public DodajIzmeniProfesoraProzor(Profesor profesor)
        {
            InitializeComponent();

            selektovaniProfesor = profesor;

            this.DataContext = profesor;

            cmbPol.ItemsSource = Enum.GetValues(typeof(EPol));

            
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
                    selektovaniProfesor.Adresa.Id = Data.Adrese.Last().Id + 1;

                }
                else
                {
                    selektovaniProfesor.Adresa.Id = 1;
                }
             
                selektovaniProfesor.TipKorisnika = ETipRegKorisnika.PROFESOR;
                selektovaniProfesor.Aktivan = true;
                Data.Adrese.Add(selektovaniProfesor.Adresa);
                Data.SacuvajAdresu("adrese.txt");
                Data.Profesori.Add(selektovaniProfesor);

            }

            //Mogucnost kad profesoru jos uvek nije pridruzena skola
            if (this.Title.Equals("Izmeni"))
            {
                if (txtSkola.Text.Equals("") || txtSkola.Text.Equals("0"))
                {
                   
                    selektovaniProfesor.Skola = new Skola();

                }
                else
                {
                    Skola sk = Data.Skole.ToList().Find(pr => pr.Id.ToString().Equals(txtSkola.Text));
                    selektovaniProfesor.Skola = sk;

                }
                
                //Zbog nekonzistentnosti upisa u fajl (kada se ide: izmena adrese -> odustani -> izmena adrese -> odustani -> izmena adrese -> sacuvaj)
                Adresa ad = Data.Adrese.ToList().Find(so => so.Id.Equals(selektovaniProfesor.Adresa.Id));
                ad.Drzava = txtDrzava.Text;
                ad.Ulica = txtUlica.Text;
                ad.Broj = int.Parse(txtBroj.Text);
                ad.Grad = txtGrad.Text;
                Data.SacuvajAdresu("adrese.txt");

            }
                 
            //Data.SacuvajAdresu("adrese.txt");
            Data.SacuvajProfesora("profesori.txt");
            this.DialogResult = true;
            this.Close();
        }
    }
}
