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
    /// Interaction logic for AdminProzor.xaml
    /// </summary>
    public partial class AdminProzor : Window
    {
        public AdminProzor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentiProzor studentiProzor = new StudentiProzor();
            studentiProzor.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SkoleProzor skoleProzor = new SkoleProzor();
            skoleProzor.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProfesoriProzor profesoriProzor = new ProfesoriProzor();
            profesoriProzor.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CasoviProzor casoviProzor = new CasoviProzor();
            casoviProzor.Show();
        }
    }
}
