using SR30_2021_POP2022.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if(cmbProfesor.SelectedItem == null)
            {
                selektovaniCas.IsValid = false;
                MessageBox.Show("Morate uneti profesora!", "Greska");
            }

            if(selektovaniCas.Error == "" && cmbProfesor.SelectedItem != null)
            {
                selektovaniCas.IsValid = true;
            }

            if (selektovaniCas.IsValid)
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
                    selektovaniCas.Profesor.Casovi.Add(selektovaniCas);
                    selektovaniCas.Student.RezervisaniCasovi.Add(selektovaniCas);
                    Data.SacuvajCas(selektovaniCas);

                }

                if (this.Title.Equals("Izmeni"))
                {   
                    //sinhronizacija izmedju prozora cas i profesor, cas i student
                    Data.IzmeniCas(selektovaniCas);
                    Data.Casovi.Clear();
                    Data.Profesori.Clear();
                    Data.UcitajProfesora();
                    Data.Studenti.Clear();
                    Data.UcitajStudenta();
                    Data.UcitajCasove();
            

                }

                this.DialogResult = true;
                this.Close();


            }
            else
            {
                MessageBox.Show(selektovaniCas.Error, "Greska");

            }



        }

    }
}
