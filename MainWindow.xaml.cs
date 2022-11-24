using SR30_2021_POP2022.Models;
using SR30_2021_POP2022.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SR30_2021_POP2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
       

        public MainWindow()
        {
            InitializeComponent();


            Data.UcitajAdrese("adrese.txt");
            Data.UcitajSkole("skole.txt");
            Data.UcitajAdmina("administratori.txt");
            Data.UcitajProfesora("profesori.txt");
            Data.UcitajStudenta("studenti.txt");
            Data.UcitajCasove("casovi.txt");

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminProzor adminProzor = new AdminProzor();
            this.Hide();
            adminProzor.Show();

        }
    }
}
