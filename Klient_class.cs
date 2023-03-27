using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace Serwis
{
    class Klient
    {

        public void AddClient()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("W celu dodania nowego klienta należy podać następujące dane:");

            Console.WriteLine("Imię Klienta: ");
            string imie;
            imie = Console.ReadLine();

            Console.WriteLine("Nazwisko Klienta: ");
            string nazwisko;
            nazwisko = Console.ReadLine();

            Console.WriteLine("Numer telefonu Klienta: ");
            string telefon;
            telefon = Console.ReadLine();

            Console.WriteLine("Adres Email Klienta: ");
            string email;
            email = Console.ReadLine();

            con.Open();
            cmd = new SqlCommand("insert into klient values ('" + imie + "', '" + nazwisko + "', '" + telefon + "', '" + email + "')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Wprowadziłeś poprawnie nowego klienta");
            con.Close();
            
            Console.ReadKey();
        }
    

        public void EditClient()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("Dla klienta o jakim ID chcesz wyedytować dane? ");
            string idedit;
            idedit = Console.ReadLine();
            Console.WriteLine("Jakie dane chcesz wyedytować? ");
            Console.WriteLine("1. Imie ");
            Console.WriteLine("2. Nazwisko ");
            Console.WriteLine("3. Telefon ");
            Console.WriteLine("4. Adres Email ");

            int optedit = int.Parse(Console.ReadLine());

            switch (optedit)
            {
                case 1:
                    string imieedit;
                    imieedit = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE klient SET imie = ('" + imieedit + "')  WHERE klient_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 2:
                    string nazwiskoedit;
                    nazwiskoedit = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE klient SET nazwisko = ('" + nazwiskoedit + "')  WHERE klient_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 3:
                    string telefonedit;
                    telefonedit = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE klient SET telefon = ('" + telefonedit + "')  WHERE klient_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 4:
                    string emailedit;
                    emailedit = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE klient SET email = ('" + emailedit + "')  WHERE klient_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
            }
            Console.ReadKey();
        }
    
        public void SearchClient()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            con.Open();
            WyszukajStart:
            Console.WriteLine("W jaki sposób chcesz wyszukiwać?");
            Console.WriteLine("1.Wyszukaj wszystkich użytkowników");
            Console.WriteLine("2.Wyszukaj po mailu");
            Console.WriteLine("3.Wróć do menu");
            int searchopt1 = int.Parse(Console.ReadLine());

            switch (searchopt1)
            {
                case 1:
                    using (SqlCommand cmdd = new SqlCommand("SELECT klient_id, imie, nazwisko, telefon, email from klient", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int klient_id = reader.GetInt32(0);
                                string imie = reader.GetString(1);
                                string nazwisko = reader.GetString(2);
                                int telefon = reader.GetInt32(3);
                                string email = reader.GetString(4);

                                
                                Console.WriteLine($"{klient_id} {imie} {nazwisko} {telefon} {email}");
                                
                            }
                        }
                    }
                    goto WyszukajStart;

                case 2:
                    Console.WriteLine("Wprowadź email:");
                    string emailsearch;
                    emailsearch = Console.ReadLine();
                    using (SqlCommand cmdd = new SqlCommand("SELECT klient_id, imie, nazwisko, telefon, email from klient WHERE email=('" + emailsearch + "')", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int klient_id = reader.GetInt32(0);
                                string imie = reader.GetString(1);
                                string nazwisko = reader.GetString(2);
                                int telefon = reader.GetInt32(3);
                                string email = reader.GetString(4);

                                
                                Console.WriteLine($"{klient_id} {imie} {nazwisko} {telefon} {email}");
                                
                            }
                        }
                    }
                    goto WyszukajStart;
                case 3:
                    break;
            }
                    con.Close();

            Console.ReadKey();
        
           
        }
    }
}