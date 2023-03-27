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
    class Urzadzenia
    {

        public void AddDevice()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("W celu dodania nowej naprawy należy podać następujące dane:");

            Console.WriteLine("Nazwa urządzenia: ");
            string urzadzenienazwa;
            urzadzenienazwa = Console.ReadLine();

            Console.WriteLine("Numer seryjny: ");
            string urzadzenienumer;
            urzadzenienumer = Console.ReadLine();

            Console.WriteLine("Opis: ");
            string urzadzenieopis;
            urzadzenieopis = Console.ReadLine();

            Console.WriteLine("ID modelu urządzenia: ");
            string urzadzenieid;
            urzadzenieid = Console.ReadLine();

           

            con.Open();
            cmd = new SqlCommand("insert into urzadzenie values ('" + urzadzenienazwa + "', '" + urzadzenienumer + "', '" + urzadzenieopis + "', '" + urzadzenieid + "')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Wprowadziłeś poprawnie nową naprawę");
            con.Close();

            Console.ReadKey();
        }
    

        public void EditDevice()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("Dla zlecenia o jakim ID chcesz wyedytować dane? ");
            string idedit;
            idedit = Console.ReadLine();
            Console.WriteLine("Jakie dane chcesz wyedytować? ");
            Console.WriteLine("1. Nazwa urządzenia ");
            Console.WriteLine("2. Numer seryjny ");
            Console.WriteLine("3. Opis ");
            Console.WriteLine("4. ID Modelu ");

            int optedit = int.Parse(Console.ReadLine());

            switch (optedit)
            {
                case 1:
                    string eurzadzenienazwa;
                    eurzadzenienazwa = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET naprawa_nazwa = ('" + eurzadzenienazwa + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 2:
                    string eurzadzenienumer;
                    eurzadzenienumer = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET opis_naprawy = ('" + eurzadzenienumer + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 3:
                    string eurzadzenieopis;
                    eurzadzenieopis = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET naprawa_data = ('" + eurzadzenieopis + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 4:
                    string eurzadzenieid;
                    eurzadzenieid = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET koszt = ('" + eurzadzenieid + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
            }
            Console.ReadKey();
        }
    
   
        public void SearchDevice()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            con.Open();
        WyszukajStart:
            Console.WriteLine("W jaki sposób chcesz wyszukiwać?");
            Console.WriteLine("1.Wyszukaj wszystkie urządzenia");
            Console.WriteLine("2.Wyszukaj urządzenia po nazwie");
            Console.WriteLine("3.Wróć do menu");
            int searchopt1 = int.Parse(Console.ReadLine());

            switch (searchopt1)
            {
                case 1:
                    using (SqlCommand cmdd = new SqlCommand("SELECT urzadzenie_id, nazwa, numer_seryjny, opis, model_id from naprawa", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int urzadzenie_id = reader.GetInt32(0);
                                string nazwa = reader.GetString(1);
                                string numer = reader.GetString(2);
                                string opis = reader.GetString(3);
                                int model = reader.GetInt32(4);


                                Console.WriteLine($"{urzadzenie_id} {nazwa} {numer} {opis} {model}");

                            }
                        }
                    }
                    goto WyszukajStart;

                case 2:
                    Console.WriteLine("Wprowadź datę:");
                    string datasearch;
                    datasearch = Console.ReadLine();
                    using (SqlCommand cmdd = new SqlCommand("SELECT urzadzenie_id, nazwa, numer_seryjny, opis, model_id from naprawa WHERE nazwa LIKE ('" + datasearch + "')", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int urzadzenie_id = reader.GetInt32(0);
                                string nazwa = reader.GetString(1);
                                string numer = reader.GetString(2);
                                string opis = reader.GetString(3);
                                int model = reader.GetInt32(4);


                                Console.WriteLine($"{urzadzenie_id} {nazwa} {numer} {opis} {model}");

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