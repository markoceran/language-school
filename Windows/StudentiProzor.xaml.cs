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
    /// Interaction logic for StudentiProzor.xaml
    /// </summary>
    public partial class StudentiProzor : Window
    {   
     
        public StudentiProzor()
        {
            InitializeComponent();

            
            dgStudenti.ItemsSource = Data.Studenti;
        }

        private void miDodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            DodajIzmeniStudentaProzor dodajIzmeniStudentaProzor = new DodajIzmeniStudentaProzor();
            dodajIzmeniStudentaProzor.Title = "Dodaj";
            dodajIzmeniStudentaProzor.Show();

        }

        private void miIzmeniStudenta_Click(object sender, RoutedEventArgs e)
        {

        }
        private void miObrisiStudenta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
