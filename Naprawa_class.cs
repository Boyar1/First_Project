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
    class Naprawa
    {

        public void AddRepair()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("W celu dodania nowej naprawy należy podać następujące dane:");

            Console.WriteLine("Nazwa naprawy: ");
            string naprawanazwa;
            naprawanazwa = Console.ReadLine();

            Console.WriteLine("Opis naprawy: ");
            string opisnaprawy;
            opisnaprawy = Console.ReadLine();

            Console.WriteLine("Data wykonania: ");
            string naprawadata;
            naprawadata = Console.ReadLine();

            Console.WriteLine("Koszt: ");
            string koszt;
            koszt = Console.ReadLine();

            Console.WriteLine("ID Pracownika wykonującego naprawę: ");
            string pracownikid;
            pracownikid = Console.ReadLine();

            Console.WriteLine("ID zlecenia dla którego jest wykonywana naprawa: ");
            string zlecenieid;
            zlecenieid = Console.ReadLine();

            con.Open();
            cmd = new SqlCommand("insert into naprawa values ('" + naprawanazwa + "', '" + opisnaprawy + "', '" + naprawadata + "', '" + koszt + "', '" + pracownikid + "', '" + zlecenieid + "')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Wprowadziłeś poprawnie nową naprawę");
            con.Close();

            Console.ReadKey();
        } 

        public void EditRepair()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("Dla zlecenia o jakim ID chcesz wyedytować dane? ");
            string idedit;
            idedit = Console.ReadLine();
            Console.WriteLine("Jakie dane chcesz wyedytować? ");
            Console.WriteLine("1. Nazwę naprawy ");
            Console.WriteLine("2. Opis naprawy ");
            Console.WriteLine("3. Data naprawy ");
            Console.WriteLine("4. Koszt naprawy ");

            int optedit = int.Parse(Console.ReadLine());

            switch (optedit)
            {
                case 1:
                    string enaprawanazwa;
                    enaprawanazwa = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET naprawa_nazwa = ('" + enaprawanazwa + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 2:
                    string eopisnaprawy;
                    eopisnaprawy = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET opis_naprawy = ('" + eopisnaprawy + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 3:
                    string enaprawadata;
                    enaprawadata = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET naprawa_data = ('" + enaprawadata + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 4:
                    string ekoszt;
                    ekoszt = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE naprawa SET koszt = ('" + ekoszt + "')  WHERE naprawa_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
            }
            Console.ReadKey();
        }
   
        public void SearchRepair()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            con.Open();
        WyszukajStart:
            Console.WriteLine("W jaki sposób chcesz wyszukiwać?");
            Console.WriteLine("1.Wyszukaj wszystkie naprawy");
            Console.WriteLine("2.Wyszukaj naprawy po dacie wykonania naprawy");
            Console.WriteLine("3.Wróć do menu");
            int searchopt1 = int.Parse(Console.ReadLine());

            switch (searchopt1)
            {
                case 1:
                    using (SqlCommand cmdd = new SqlCommand("SELECT naprawa_id, naprawa_nazwa, opis_naprawy, naprawa_data, koszt from naprawa", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int naprawa_id = reader.GetInt32(0);
                                string naprawa_nazwa = reader.GetString(1);
                                string opis_nazwa = reader.GetString(2);
                                DateTime naprawa_data = reader.GetDateTime(3);
                                decimal koszt = reader.GetDecimal(4);


                                Console.WriteLine($"{naprawa_id} {naprawa_nazwa} {opis_nazwa} {naprawa_data} {koszt}");

                            }
                        }
                    }
                    goto WyszukajStart;

                case 2:
                    Console.WriteLine("Wprowadź datę:");
                    string datasearch;
                    datasearch = Console.ReadLine();
                    using (SqlCommand cmdd = new SqlCommand("SELECT naprawa_id, naprawa_nazwa, opis_naprawy, naprawa_data, koszt from naprawa WHERE naprawa_data=('" + datasearch + "')", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int naprawa_id = reader.GetInt32(0);
                                string naprawa_nazwa = reader.GetString(1);
                                string opis_nazwa = reader.GetString(2);
                                DateTime naprawa_data = reader.GetDateTime(3);
                                decimal koszt = reader.GetDecimal(4);


                                Console.WriteLine($"{naprawa_id} {naprawa_nazwa} {opis_nazwa} {naprawa_data} {koszt}");

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