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


            Data.UcitajAdrese();
            Data.UcitajSkole();
            Data.UcitajAdmina();
            Data.UcitajProfesora();
            Data.UcitajStudenta();
            Data.UcitajCasove();
            Data.UcitajJezike();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GostProzor gostProzor = new GostProzor();
            this.Hide();
            gostProzor.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminProzor adminProzor = new AdminProzor();
            this.Hide();
            adminProzor.Show();

        }
    }
}
