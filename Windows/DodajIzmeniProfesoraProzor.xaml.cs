using SR30_2021_POP2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for DodajIzmeniProfesoraProzor.xaml
    /// </summary>
    public partial class DodajIzmeniProfesoraProzor : Window
    {
        private Profesor selektovaniProfesor;
        ICollectionView viewJezici;

        public DodajIzmeniProfesoraProzor(Profesor profesor)
        {
            InitializeComponent();

            selektovaniProfesor = profesor;

            this.DataContext = profesor;

            cmbPol.ItemsSource = Enum.GetValues(typeof(EPol));
            cmbSkola.ItemsSource = Data.Skole;
              

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Profesori.ToList().Find(so => so.Email.Equals(selektovaniProfesor.Email)) != null && this.Title.Equals("Dodaj"))
            {
                selektovaniProfesor.IsValid = false;
                
            }          

            if (selektovaniProfesor.IsValid) {

                if (this.Title.Equals("Dodaj"))
                {
                    if (!Data.Adrese.Count.Equals(0))
                    {
                        selektovaniProfesor.Adresa.Id = Data.Adrese.Last().Id + 1;

                    }
                    else
                    {
                        selektovaniProfesor.Adresa.Id = 1;
                    }

                    selektovaniProfesor.TipKorisnika = ETipRegKorisnika.PROFESOR;
                    selektovaniProfesor.Aktivan = true;

                    Data.Adrese.Add(selektovaniProfesor.Adresa);
                    Data.SacuvajAdresu(selektovaniProfesor.Adresa);
                 
                    Data.Profesori.Add(selektovaniProfesor);
                    Data.SacuvajProfesora(selektovaniProfesor);

                    if (listBoxJezici.SelectedItems.Count > 0)
                    {

                        foreach (string i in listBoxJezici.SelectedItems)
                        {
                            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
                            {
                                conn.Open();

                                string users = "select * from JezikProfesor";

                                DataSet ds = new DataSet();
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                                dataAdapter.Fill(ds, "JezikProfesor");


                                DataRow newRow = ds.Tables["JezikProfesor"].NewRow();
                                newRow["ProfesorEmail"] = selektovaniProfesor.Email;
                                newRow["Jezik"] = i;

                                ds.Tables["JezikProfesor"].Rows.Add(newRow);

                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                                dataAdapter.Update(ds.Tables["JezikProfesor"]);


                            }

                            selektovaniProfesor.Jezici.Add(i);

                        }

                    }
                }

               
                if (this.Title.Equals("Izmeni"))
                {
                    if (listBoxJezici.SelectedItems.Count > 0)
                    {
                        Data.IzmeniJezikProfesora(selektovaniProfesor, listBoxJezici.SelectedItems);

                    }

                    /*else
                    {                                            
                        selektovanaSkola.Jezici = Data.Skole.ToList().Find(s => s.Id.Equals(selektovanaSkola.Id)).Jezici;
                    }*/

                    Data.IzmeniAdresu(selektovaniProfesor.Adresa);
                    Data.IzmeniProfesora(selektovaniProfesor);

                }

               
                this.DialogResult = true;
                this.Close();

            }
            else
            {
                MessageBox.Show(selektovaniProfesor.Error, "Greska");
        
            }
          
        }

        private void cmbSkola_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbSkola.SelectedItem != null)
            {
                Skola selektovanaSkola = (Skola)cmbSkola.SelectedItem;

                viewJezici = CollectionViewSource.GetDefaultView(selektovanaSkola.Jezici);
                listBoxJezici.ItemsSource = viewJezici;
                viewJezici.Refresh();

            }
        }
    }
}
