using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        

//---------------------------------------------------------------------------------------------------------

       /* public static void SacuvajAdmina(string filename)
         {
                using (StreamWriter file = new StreamWriter(@"../../../Resources/" + filename))
                {
                    foreach (RegistrovaniKorisnik registrovaniKorisnik in Administratori)
                    {
                        file.WriteLine(registrovaniKorisnik.KorisnikZaUpisUFajl());
                    }
                }
         }
       */


        public static void SacuvajProfesora(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Profesor profesor in Profesori)
                {
                    file.WriteLine(profesor.ProfesorZaUpisUFajl());
                }
            }
        }

        public static void SacuvajStudenta(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Student student in Studenti)
                {
                    file.WriteLine(student.StudentZaUpisUFajl());
                }
            }
        }

        public static void SacuvajAdresu(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Adresa adresa in Adrese)
                {
                    file.WriteLine(adresa.AdresaZaUpisUFajl());
                }
            }
        }

        public static void SacuvajCas(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Cas cas in Casovi)
                {
                    file.WriteLine(cas.CasZaUpisUFajl());
                }
            }
        }

        public static void SacuvajSkolu(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Skola skola in Skole)
                {
                    file.WriteLine(skola.SkolaZaUpisUFajl());
                }
            }
        }


        //---------------------------------------------------------------------------------------------------------

        public static void UcitajAdmina(string filename)
        {
                

                using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
                {
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        string[] korisnikIzFajla = line.Split(';');


                        Enum.TryParse(korisnikIzFajla[3], out EPol pol);
                        Enum.TryParse(korisnikIzFajla[7], out ETipRegKorisnika tip);
                        Boolean.TryParse(korisnikIzFajla[8], out Boolean aktivan);

                        string adresaId = korisnikIzFajla[4];


                        Adresa a = Adrese.ToList().Find(k => k.Id.ToString().Contains(adresaId));
                    

                        RegistrovaniKorisnik admin = new RegistrovaniKorisnik
                        {

                                Ime = korisnikIzFajla[0],
                                Prezime = korisnikIzFajla[1],
                                Jmbg = korisnikIzFajla[2],
                                Pol = pol,
                                Adresa = a,
                                Email = korisnikIzFajla[5],
                                Lozinka = korisnikIzFajla[6],
                                TipKorisnika = tip,
                                Aktivan = aktivan
 
                            
                        };

                        Administratori.Add(admin);
                    }
                }

        }


        public static void UcitajProfesora(string filename)
        {


            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');


                    Enum.TryParse(korisnikIzFajla[3], out EPol pol);
                    Enum.TryParse(korisnikIzFajla[7], out ETipRegKorisnika tip);
                    Boolean.TryParse(korisnikIzFajla[11], out Boolean aktivan);

                    string adresaId = korisnikIzFajla[4];
                    string skolaId = korisnikIzFajla[8];

                    Adresa a = new Adresa();

                    foreach(Adresa ad in Adrese)
                    {
                        if(ad.Id.ToString() == adresaId)
                        {
                            a = ad;
                        }
                    }

                    //Adresa a = Adrese.ToList().Find(k => k.Id.ToString().Contains(adresaId));
                    Skola s = Skole.ToList().Find(k => k.Id.ToString().Contains(skolaId));

                    Profesor profesor = new Profesor
                    {

                        Ime = korisnikIzFajla[0],
                        Prezime = korisnikIzFajla[1],
                        Jmbg = korisnikIzFajla[2],
                        Pol = pol,
                        Adresa = a,
                        Email = korisnikIzFajla[5],
                        Lozinka = korisnikIzFajla[6],
                        TipKorisnika = tip,
                        Jezici = new List<string>(),
                        Casovi = new List<Cas>(),
                        Aktivan = aktivan


                    };

                    if (!skolaId.Equals("0"))
                    {

                        Skola sk = Skole.ToList().Find(k => k.Id.ToString().Equals(skolaId));
                        profesor.Skola = sk;


                    }

                    Profesori.Add(profesor);
                }
            }

        }


        public static void UcitajStudenta(string filename)
        {


            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');


                    Enum.TryParse(korisnikIzFajla[3], out EPol pol);
                    Enum.TryParse(korisnikIzFajla[7], out ETipRegKorisnika tip);
                    Boolean.TryParse(korisnikIzFajla[9], out Boolean aktivan);

                    string adresaId = korisnikIzFajla[4];

                    Adresa a = new Adresa();
                    foreach (Adresa ad in Adrese)
                    {
                        if (ad.Id.ToString() == adresaId)
                        {
                            a = ad;
                        }
                    }

                    //Adresa a = Adrese.ToList().Find(k => k.Id.ToString().Contains(adresaId));


                    Student student = new Student
                    {

                        Ime = korisnikIzFajla[0],
                        Prezime = korisnikIzFajla[1],
                        Jmbg = korisnikIzFajla[2],
                        Pol = pol,
                        Adresa = a,
                        Email = korisnikIzFajla[5],
                        Lozinka = korisnikIzFajla[6],
                        TipKorisnika = tip,
                        RezervisaniCasovi = new List<Cas>(),
                        Aktivan = aktivan


                    };

                    Studenti.Add(student);
                }
            }

        }


        public static void UcitajCasove(string filename)
        {


            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');


                    
                    Enum.TryParse(korisnikIzFajla[5], out EStatusCasa status);
                    DateTime.TryParse(korisnikIzFajla[2], out DateTime datum);
                    Boolean.TryParse(korisnikIzFajla[7], out Boolean obrisan);

                    string profesorEmail = korisnikIzFajla[1];
                    string studentEmail = korisnikIzFajla[6];

                    Cas cas = new Cas
                    {

                        Id = Int32.Parse(korisnikIzFajla[0]),
                        DatumOdrzavanja = datum,
                        VremePocetka = korisnikIzFajla[3],
                        Trajanje = Int32.Parse(korisnikIzFajla[4]),
                        Status = status,                    
                        Obrisan = obrisan


                    };


                    if (!profesorEmail.Equals(""))
                    {
                        
                        Profesor p = Profesori.ToList().Find(k => k.Email.Contains(profesorEmail));
                        cas.Profesor = p;


                    }


                    if (!studentEmail.Equals(""))
                    {
                        Student s = Studenti.ToList().Find(k => k.Email.Contains(studentEmail));
                        cas.Student = s;

                    }                    

                    Casovi.Add(cas);
                }
            }

        }


        public static void UcitajSkole(string filename)
        {


            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');
                 
      
                    string adresaId = korisnikIzFajla[2];                    

                    Adresa a = Adrese.ToList().Find(k => k.Id.ToString().Contains(adresaId));
                    Boolean.TryParse(korisnikIzFajla[4], out Boolean obrisana);

                    Skola skola = new Skola
                    {

                        Id = Int32.Parse(korisnikIzFajla[0]),
                        Naziv = korisnikIzFajla[1],
                        Adresa = a,
                        Jezici = new List<string>(),
                        Obrisana = obrisana


                    };

                    Skole.Add(skola);
                }
            }

        }


        public static void UcitajAdrese(string filename)
        {


            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');
                

                    Adresa adresa = new Adresa
                    {

                        Id = Int32.Parse(korisnikIzFajla[0]),
                        Ulica = korisnikIzFajla[1],
                        Broj = Int32.Parse(korisnikIzFajla[2]),
                        Grad = korisnikIzFajla[3],
                        Drzava = korisnikIzFajla[4]


                    };

                    Adrese.Add(adresa);
                }
            }

        }



        //---------------------------------------------------------------------------------------------------------


        public static void ObrisiProfesora(string email)
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

        //---------------------------------------------------------------------------------------------------------


    }
}
      