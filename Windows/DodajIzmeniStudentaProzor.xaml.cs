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
    /// Interaction logic for DodajIzmeniStudentaProzor.xaml
    /// </summary>
    public partial class DodajIzmeniStudentaProzor : Window
    {
        private Student selektovaniStudent;

        public DodajIzmeniStudentaProzor(Student student)
        {   
            InitializeComponent();

            selektovaniStudent = student;

            this.DataContext = student;

            cmbPol.ItemsSource = Enum.GetValues(typeof(EPol));

 

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Profesori.ToList().Find(so => so.Email.Equals(selektovaniStudent.Email)) != null && this.Title.Equals("Dodaj"))
            {
                selektovaniStudent.IsValid = false;

            }

            if (selektovaniStudent.IsValid) {


                if (this.Title.Equals("Dodaj"))
                {

                    if (!Data.Adrese.Count.Equals(0))
                    {
                        selektovaniStudent.Adresa.Id = Data.Adrese.Last().Id + 1;

                    }
                    else
                    {
                        selektovaniStudent.Adresa.Id = 1;
                    }

                    selektovaniStudent.TipKorisnika = ETipRegKorisnika.STUDENT;
                    selektovaniStudent.Aktivan = true;

                    Data.Adrese.Add(selektovaniStudent.Adresa);
                    Data.SacuvajAdresu(selektovaniStudent.Adresa);

                    Data.Studenti.Add(selektovaniStudent);
                    Data.SacuvajStudenta(selektovaniStudent);

                }

               
                if (this.Title.Equals("Izmeni"))
                {

                    /*Adresa ad = Data.Adrese.ToList().Find(so => so.Id.Equals(selektovaniStudent.Adresa.Id));
                    ad.Drzava = txtDrzava.Text;
                    ad.Ulica = txtUlica.Text;
                    ad.Broj = int.Parse(txtBroj.Text);
                    ad.Grad = txtGrad.Text;
                    Data.SacuvajAdresu(selektovaniStudent.Adresa);*/
                    Data.IzmeniAdresu(selektovaniStudent.Adresa);
                    Data.IzmeniStudenta(selektovaniStudent);

                }


                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(selektovaniStudent.Error, "Greska");

            }


        }

    }
}
