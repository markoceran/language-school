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
                if (!txtProfesor.Text.Equals(""))
                {
                    Profesor p = Data.Profesori.ToList().Find(pr => pr.Email.Contains(txtProfesor.Text));
                    selektovaniCas.Profesor = p;


                }
                
               
                selektovaniCas.Student = new Student();
                
                selektovaniCas.Status = EStatusCasa.SLOBODAN;
                selektovaniCas.Obrisan = false;
                Data.Casovi.Add(selektovaniCas);

            }

            if (this.Title.Equals("Izmeni"))
            {
                if (!txtProfesor.Text.Equals(""))
                {
                    Profesor p = Data.Profesori.ToList().Find(pr => pr.Email.Contains(txtProfesor.Text));
                    selektovaniCas.Profesor = p;

                }
                else
                {
                    selektovaniCas.Profesor = new Profesor();
                    
                }

                if (!txtStudent.Text.Equals(""))
                {
                    Student s = Data.Studenti.ToList().Find(pr => pr.Email.Contains(txtStudent.Text));
                    selektovaniCas.Student = s;


                }
                else
                {
                    selektovaniCas.Student = new Student();
                   
                }
                    
           

            }

            Data.SacuvajCas("casovi.txt");
            this.DialogResult = true;
            this.Close();


        }
    }
}
