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
    /// Interaction logic for ProfesoriProzor.xaml
    /// </summary>
    public partial class ProfesoriProzor : Window
    {
        public ProfesoriProzor()
        {
            InitializeComponent();

            dgProfesori.ItemsSource = Models.Data.Profesori;
        }

        private void miDodajProfesora_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miIzmeniProfesora_Click(object sender, RoutedEventArgs e)
        {

        }
        private void miObrisiProfesora_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
