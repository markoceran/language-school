﻿using SR30_2021_POP2022.Models;
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
            
            if (this.Title.Equals("Dodaj")){

                selektovaniStudent.TipKorisnika = ETipRegKorisnika.STUDENT;
                selektovaniStudent.Aktivan = true;
                Data.Studenti.Add(selektovaniStudent);                         
               
            }
           
            Data.SacuvajStudenta("studenti.txt");
            this.DialogResult = true;
            this.Close();
        }

    }
}
