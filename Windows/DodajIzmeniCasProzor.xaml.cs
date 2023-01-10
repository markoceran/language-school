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
    /// Interaction logic for DodajIzmeniCasProzor.xaml
    /// </summary>
    public partial class DodajIzmeniCasProzor : Window
    {
        private Cas selektovaniCas;

        public DodajIzmeniCasProzor(Cas cas)
        {
            InitializeComponent();

            selektovaniCas = cas;

            this.DataContext = cas;

            cmbStatus.ItemsSource = Enum.GetValues(typeof(EStatusCasa));
            cmbProfesor.ItemsSource = Data.Profesori;
            cmbStudent.ItemsSource = Data.Studenti;
          
            pickerDatum.DisplayDateStart = DateTime.Now;
            
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
                if (!Data.Casovi.Count.Equals(0))
                {
                    selektovaniCas.Id = Data.Casovi.Last().Id + 1;

                }
                else
                {
                    selektovaniCas.Id = 1;
                }

                selektovaniCas.Status = EStatusCasa.SLOBODAN;
                selektovaniCas.Obrisan = false;

                Data.Casovi.Add(selektovaniCas);
                Data.SacuvajCas(selektovaniCas);

            }

            if (this.Title.Equals("Izmeni"))
            {             
                Data.IzmeniCas(selektovaniCas);

            }

            this.DialogResult = true;
            this.Close();

        }
    }
}
