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
    /// Interaction logic for SkoleProzor.xaml
    /// </summary>
    public partial class SkoleProzor : Window
    {
        public SkoleProzor()
        {
            InitializeComponent();

            dgSkole.ItemsSource = Models.Data.Skole;
        }

        private void miDodajSkolu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miIzmeniSkolu_Click(object sender, RoutedEventArgs e)
        {

        }
        private void miObrisiSkolu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
