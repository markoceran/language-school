using SR30_2021_POP2022.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for DodajIzmeniSkoluProzor.xaml
    /// </summary>
    public partial class DodajIzmeniSkoluProzor : Window
    {
        private Skola selektovanaSkola;
        ICollectionView viewJezici;
     

        public DodajIzmeniSkoluProzor(Skola skola)
        {
            InitializeComponent();

            selektovanaSkola = skola;

            this.DataContext = skola;

            viewJezici = CollectionViewSource.GetDefaultView(Data.Jezici);
            listBoxJezici.ItemsSource = viewJezici;

            

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            /*if(listBoxJezici.SelectedItems.Count)
            {
                selektovanaSkola.IsValid = false;
                
            }  */

            
                if (this.Title.Equals("Dodaj"))
                {

                    if (!Data.Adrese.Count.Equals(0))
                    {
                        selektovanaSkola.Adresa.Id = Data.Adrese.Last().Id + 1;

                    }
                    else
                    {
                        selektovanaSkola.Adresa.Id = 1;
                    }

                    if (!Data.Skole.Count.Equals(0))
                    {
                        selektovanaSkola.Id = Data.Skole.Last().Id + 1;

                    }
                    else
                    {
                        selektovanaSkola.Id = 1;
                    }

                    selektovanaSkola.Obrisana = false;



                    Data.Adrese.Add(selektovanaSkola.Adresa);
                    Data.SacuvajAdresu(selektovanaSkola.Adresa);

                    Data.Skole.Add(selektovanaSkola);
                    Data.SacuvajSkolu(selektovanaSkola);


                    if (listBoxJezici.SelectedItems.Count > 0)
                    {

                        foreach (string i in listBoxJezici.SelectedItems)
                        {
                            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
                            {
                                conn.Open();

                                string users = "select * from JezikSkola";

                                DataSet ds = new DataSet();
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                                dataAdapter.Fill(ds, "JezikSkola");


                                DataRow newRow = ds.Tables["JezikSkola"].NewRow();
                                newRow["SkolaId"] = selektovanaSkola.Id;
                                newRow["Jezik"] = i;

                                ds.Tables["JezikSkola"].Rows.Add(newRow);

                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                                dataAdapter.Update(ds.Tables["JezikSkola"]);


                            }

                            selektovanaSkola.Jezici.Add(i);

                        }

                    }
                   

                }

                
                if (this.Title.Equals("Izmeni"))
                {                                    

                    if(listBoxJezici.SelectedItems.Count > 0)
                    {
                        Data.IzmeniJezikSkole(selektovanaSkola, listBoxJezici.SelectedItems);

                    }

                    /*else
                    {                                            
                        selektovanaSkola.Jezici = Data.Skole.ToList().Find(s => s.Id.Equals(selektovanaSkola.Id)).Jezici;
                    }*/

                    Data.IzmeniAdresu(selektovanaSkola.Adresa);
                    Data.IzmeniSkolu(selektovanaSkola);

                }
           
                this.DialogResult = true;
                this.Close();

        }
            

        private void btnDodajNoviJezik_Click(object sender, RoutedEventArgs e)
        {
           
            if (txtDodajNoviJezik.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
                {
                    conn.Open();
                    DataSet ds = new DataSet();

                    string users = "select * from Jezik";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                    dataAdapter.Fill(ds, "Jezik");

                    DataRow newRow = ds.Tables["Jezik"].NewRow();
                    newRow["Naziv"] = txtDodajNoviJezik.Text;
                   
                    ds.Tables["Jezik"].Rows.Add(newRow);

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(ds.Tables["Jezik"]);
                   
                }

                Data.Jezici.Add(txtDodajNoviJezik.Text);
                viewJezici.Refresh();
                txtDodajNoviJezik.Text = "";              
            }
            
        }
    }
    
}
