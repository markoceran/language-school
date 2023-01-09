using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SR30_2021_POP2022.Exceptions;


namespace SR30_2021_POP2022.Models
{
    public class Data
    {

        public static ObservableCollection<RegistrovaniKorisnik> Administratori = new ObservableCollection<RegistrovaniKorisnik>();
        public static ObservableCollection<Profesor> Profesori = new ObservableCollection<Profesor>();
        public static ObservableCollection<Student> Studenti = new ObservableCollection<Student>();
        public static ObservableCollection<Adresa> Adrese = new ObservableCollection<Adresa>();
        public static ObservableCollection<Cas> Casovi = new ObservableCollection<Cas>();
        public static ObservableCollection<Skola> Skole = new ObservableCollection<Skola>();

        public static readonly string CONNECTION_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\FTN PREDAVANJA I MATERIJAL\\Platforme za objektno programiranje\\SR30-2021-POP2022\\Database.mdf\";Integrated Security=True;Connect Timeout=30";


        //---------------------------------------------------------------------------------------------------------


        public static int SacuvajProfesora(Profesor profesor)
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string users = "select * from Profesor";

                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "Profesor");

               
                DataRow newRow = ds.Tables["Profesor"].NewRow();            
                newRow["Ime"] = profesor.Ime;
                newRow["Prezime"] = profesor.Prezime;
                newRow["Jmbg"] = profesor.Jmbg;
                newRow["Email"] = profesor.Email;
                newRow["Lozinka"] = profesor.Lozinka;
                newRow["AdresaId"] = profesor.Adresa.Id;
                newRow["SkolaId"] = profesor.Skola.Id;
                newRow["Pol"] = profesor.Pol;
                newRow["TipKorisnika"] = profesor.TipKorisnika;
                newRow["Aktivan"] = profesor.Aktivan;

                ds.Tables["Profesor"].Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["Profesor"]);

                return Profesori.Count + 1; //vracam id kao povratnu vrednost
            }
        }


        public static void IzmeniProfesora(Profesor profesor)
        {
            
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"update dbo.Profesor
                set Ime = @Ime,Prezime = @Prezime,Jmbg = @Jmbg,Email = @Email,Lozinka = @Lozinka,
                    AdresaId = @AdresaId, SkolaId = @SkolaId, Pol = @Pol,TipKorisnika = @TipKorisnika,Aktivan=@Aktivan
                    where Email = @Email";

                Enum.TryParse("" + profesor.Pol + "", out EPol pol);
               
                
                command.Parameters.Add(new SqlParameter("Ime", profesor.Ime));
                command.Parameters.Add(new SqlParameter("Prezime", profesor.Prezime));
                command.Parameters.Add(new SqlParameter("Jmbg", profesor.Jmbg));
                command.Parameters.Add(new SqlParameter("Email", profesor.Email));
                command.Parameters.Add(new SqlParameter("Lozinka", profesor.Lozinka));
                command.Parameters.Add(new SqlParameter("AdresaId", profesor.Adresa.Id));
                command.Parameters.Add(new SqlParameter("SkolaId", profesor.Skola.Id));
                command.Parameters.Add(new SqlParameter("Pol", pol.ToString()));
                command.Parameters.Add(new SqlParameter("TipKorisnika", ETipRegKorisnika.PROFESOR.ToString()));
                command.Parameters.Add(new SqlParameter("Aktivan", profesor.Aktivan));
                command.ExecuteScalar();
            }
        }

        public static void IzmeniAdresu(Adresa adresa)
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"update dbo.Adresa
                set Id = @Id, Drzava = @Drzava, Grad = @Grad,Ulica = @Ulica,Broj = @Broj where Id = @Id";

                command.Parameters.Add(new SqlParameter("Id", adresa.Id));
                command.Parameters.Add(new SqlParameter("Drzava", adresa.Drzava));
                command.Parameters.Add(new SqlParameter("Grad", adresa.Grad));
                command.Parameters.Add(new SqlParameter("Ulica", adresa.Ulica));
                command.Parameters.Add(new SqlParameter("Broj", adresa.Broj));
                command.ExecuteScalar();
            }
        }


        public static int SacuvajStudenta(Student student)
        {
            using(SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string users = "select * from Student";
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "Student");

                DataRow newRow = ds.Tables["Student"].NewRow();
                newRow["Ime"] = student.Ime;
                newRow["Prezime"] = student.Prezime;
                newRow["Jmbg"] = student.Jmbg;
                newRow["Email"] = student.Email;
                newRow["Lozinka"] = student.Lozinka;
                newRow["AdresaId"] = student.Adresa.Id;
                newRow["Pol"] = student.Pol;
                newRow["TipKorisnika"] = student.TipKorisnika;
                newRow["Aktivan"] = student.Aktivan;

                ds.Tables["Student"].Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["Student"]);

                return Studenti.Count + 1;
                
            }
        }

        public static int SacuvajAdresu(Adresa adresa)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string users = "select * from Adresa";

                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "Adresa");


                DataRow newRow = ds.Tables["Adresa"].NewRow();
                newRow["Id"] = adresa.Id;
                newRow["Drzava"] = adresa.Drzava;
                newRow["Grad"] = adresa.Grad;
                newRow["Ulica"] = adresa.Ulica;
                newRow["Broj"] = adresa.Broj;
                

                ds.Tables["Adresa"].Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["Adresa"]);

                return Adrese.Count + 1; //vracam id kao povratnu vrednost
            }
        }

        public static int SacuvajCas(Cas cas)
        {
            using(SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();
                string users = "select * from Cas"; 
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "Cas");

                DataRow newRow = ds.Tables["Cas"].NewRow();
                newRow["Id"] = cas.Id;
                newRow["ProfesorEmail"] = cas.Profesor.Email;
                newRow["StudentEmail"] = cas.Student.Email;
                newRow["DatumOdrzavanja"] = cas.DatumOdrzavanja;
                newRow["VremePocetka"] = cas.VremePocetka;
                newRow["Trajanje"] = cas.Trajanje;
                newRow["Status"] = cas.Status;
                newRow["Obrisan"] = cas.Obrisan;

                ds.Tables["Cas"].Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["Cas"]);

                return Casovi.Count + 1;
            }
        }

        public static int SacuvajSkolu(Skola skola)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string users = "select * from Skola";

                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "Skola");


                DataRow newRow = ds.Tables["Skola"].NewRow();
                newRow["Id"] = skola.Id;
                newRow["Naziv"] = skola.Naziv;
                newRow["AdresaId"] = skola.Adresa.Id;
                newRow["Obrisana"] = skola.Obrisana;
                


                ds.Tables["Skola"].Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["Skola"]);

                return Skole.Count + 1; //vracam id kao povratnu vrednost
            }
        }


        //---------------------------------------------------------------------------------------------------------

        public static void UcitajAdmina()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from Administrator";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "Administrator");

                foreach (DataRow dataRow in ds.Tables["Administrator"].Rows)
                {
                    Enum.TryParse(dataRow["Pol"].ToString(), out EPol pol);
                    Enum.TryParse(dataRow["TipKorisnika"].ToString(), out ETipRegKorisnika tip);

                    RegistrovaniKorisnik admin = new RegistrovaniKorisnik
                    {
                        Ime = dataRow["Ime"].ToString(),
                        Prezime = dataRow["Prezime"].ToString(),
                        Jmbg = dataRow["Jmbg"].ToString(),
                        Email = dataRow["Email"].ToString(),
                        Lozinka = dataRow["Lozinka"].ToString(),
                        Adresa = Adrese.ToList().Find(a => a.Id.ToString().Equals(dataRow["AdresaId"].ToString())),                       
                        Pol = pol,
                        TipKorisnika = tip,
                        Aktivan = (bool)dataRow["Aktivan"]


                    };
                    Administratori.Add(admin);
                }
            }

        }


        public static void UcitajProfesora()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from Profesor";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "Profesor");

                foreach (DataRow dataRow in ds.Tables["Profesor"].Rows)
                {
                    Enum.TryParse(dataRow["Pol"].ToString(), out EPol pol);
                    Enum.TryParse(dataRow["TipKorisnika"].ToString(), out ETipRegKorisnika tip);

                    Profesor profesor = new Profesor
                    {
                        Ime = dataRow["Ime"].ToString(),
                        Prezime = dataRow["Prezime"].ToString(),
                        Jmbg = dataRow["Jmbg"].ToString(),
                        Email = dataRow["Email"].ToString(),
                        Lozinka = dataRow["Lozinka"].ToString(),
                        Adresa = Adrese.ToList().Find(a => a.Id.ToString().Equals(dataRow["AdresaId"].ToString())),
                        Skola = Skole.ToList().Find(s => s.Id.ToString().Equals(dataRow["SkolaId"].ToString())),                    
                        Pol = pol,
                        TipKorisnika = tip,
                        Aktivan = (bool)dataRow["Aktivan"]
                        
                        
                    };
                    Profesori.Add(profesor);
                }
            }

        }


        public static void UcitajStudenta()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from Student";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "Student");

                foreach (DataRow dataRow in ds.Tables["Student"].Rows)
                {
                    Enum.TryParse(dataRow["Pol"].ToString(), out EPol pol);
                    Enum.TryParse(dataRow["TipKorisnika"].ToString(), out ETipRegKorisnika tip);

                    Student student = new Student
                    {
                        Ime = dataRow["Ime"].ToString(),
                        Prezime = dataRow["Prezime"].ToString(),
                        Jmbg = dataRow["Jmbg"].ToString(),
                        Email = dataRow["Email"].ToString(),
                        Lozinka = dataRow["Lozinka"].ToString(),
                        Adresa = Adrese.ToList().Find(a => a.Id.ToString().Equals(dataRow["AdresaId"].ToString())),                       
                        Pol = pol,
                        TipKorisnika = tip,
                        Aktivan = (bool)dataRow["Aktivan"]


                    };
                    Studenti.Add(student);
                }
            }

        }


        public static void UcitajCasove()
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from Cas";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "Cas");

                foreach (DataRow dataRow in ds.Tables["Cas"].Rows)
                {
                   
                    Enum.TryParse(dataRow["Status"].ToString(), out EStatusCasa status);

                    Cas cas = new Cas
                    {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Profesor = Profesori.ToList().Find(p => p.Email.Equals(dataRow["ProfesorEmail"].ToString())),
                        Student = Studenti.ToList().Find(s => s.Email.Equals(dataRow["StudentEmail"].ToString())),
                        DatumOdrzavanja = DateTime.Parse(dataRow["DatumOdrzavanja"].ToString()),
                        VremePocetka = dataRow["VremePocetka"].ToString(),
                        Trajanje = int.Parse(dataRow["Trajanje"].ToString()),
                        Status = status,
                        Obrisan = (bool)dataRow["Obrisan"]
                        

                    };
                    Casovi.Add(cas);
                }
            }

        }


        public static void UcitajSkole()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from Skola";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "Skola");

                foreach (DataRow dataRow in ds.Tables["Skola"].Rows)
                {

                    Skola skola = new Skola
                    {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Naziv = dataRow["Naziv"].ToString(),
                        Adresa = Adrese.ToList().Find(a => a.Id.ToString().Equals(dataRow["AdresaId"].ToString())),                      
                        Obrisana = (bool)dataRow["Obrisana"]


                    };
                    Skole.Add(skola);
                }
            }

        }


        public static void UcitajAdrese()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from Adresa";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "Adresa");

                foreach (DataRow dataRow in ds.Tables["Adresa"].Rows)
                {

                    Adresa adresa = new Adresa
                    {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Drzava = dataRow["Drzava"].ToString(),
                        Grad = dataRow["Grad"].ToString(),
                        Ulica = dataRow["Ulica"].ToString(),
                        Broj = int.Parse(dataRow["Broj"].ToString())


                    };
                    Adrese.Add(adresa);
                }
            }

        }



        //---------------------------------------------------------------------------------------------------------


        /*public static void ObrisiProfesora(string email)
        {
             Profesor p = Profesori.ToList().Find(k => k.Email.Contains(email));
             if (p == null)
             {
                 throw new UserNotFoundException($"Ne postoji taj korisnik sa email adresom {email}");
             }
             p.Aktivan = false;
            SacuvajProfesora("profesori.txt");
        }

        public static void ObrisiStudenta(string email)
        {
            Student s = Studenti.ToList().Find(k => k.Email.Contains(email));
            if (s == null)
            {
                throw new UserNotFoundException($"Ne postoji taj korisnik sa email adresom {email}");
            }
            s.Aktivan = false;
            SacuvajStudenta("studenti.txt");
        }

        public static void ObrisiSkolu(int id)
        {
            Skola s = Skole.ToList().Find(sk => sk.Id == id);
            if (s == null)
            {
                throw new UserNotFoundException($"Ne postoji skola sa id {id}");
            }
            s.Obrisana = true;
            SacuvajSkolu("skole.txt");
        }

        public static void ObrisiCas(int id)
        {
            Cas c = Casovi.ToList().Find(k => k.Id == (id));
            if (c == null)
            {
                throw new UserNotFoundException($"Ne postoji taj cas koji ima id {id}");
            }
            c.Obrisan = true;
            SacuvajCas("casovi.txt");
        }
        */
        //---------------------------------------------------------------------------------------------------------


    }
}
      