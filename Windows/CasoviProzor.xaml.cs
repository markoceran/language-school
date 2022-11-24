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
    /// Interaction logic for CasoviProzor.xaml
    /// </summary>
    public partial class CasoviProzor : Window
    {
        public CasoviProzor()
        {
            InitializeComponent();

            dgCasovi.ItemsSource = Models.Data.Casovi;
        }

        private void miDodajCas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miIzmeniCas_Click(object sender, RoutedEventArgs e)
        {

        }
        private void miObrisiCas_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
