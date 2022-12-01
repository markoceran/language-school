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

                


                Adresa a = Data.Adrese.ToList().Find(k => k.Id.ToString().Contains(txtAdresa.Text));
                Skola sk = Data.Skole.ToList().Find(s => s.Id.ToString().Contains(txtSkola.Text));
                selektovaniProfesor.Adresa = a;
                selektovaniProfesor.Skola = sk;

                selektovaniProfesor.TipKorisnika = ETipRegKorisnika.PROFESOR;
                selektovaniProfesor.Aktivan = true;
                Data.Profesori.Add(selektovaniProfesor);

            }

            Data.SacuvajProfesora("profesori.txt");
            this.DialogResult = true;
            this.Close();
        }
    }
}
