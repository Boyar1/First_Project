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
    class Zlecenie
    {

        public void AddJob()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("W celu dodania nowego zlecenia należy podać następujące dane:");

            Console.WriteLine("Opis zlecenia: ");
            string opiszlecenia;
            opiszlecenia = Console.ReadLine();

            Console.WriteLine("Data złożenia zlecenia: ");
            string datazlecenia;
            datazlecenia = Console.ReadLine();

            Console.WriteLine("Data wykonania zlecenia: ");
            string datawykonania;
            datawykonania = Console.ReadLine();

            Console.WriteLine("Status zlecenia: ");
            string statuszlecenia;
            statuszlecenia = Console.ReadLine();

            Console.WriteLine("ID Klienta: ");
            string klientid;
            klientid = Console.ReadLine();

            Console.WriteLine("ID urządzenia: ");
            string statusid;
            statusid = Console.ReadLine();

            con.Open();
            cmd = new SqlCommand("insert into zlecenie values ('" + opiszlecenia + "', '" + datazlecenia + "', '" + datawykonania + "', '" + statuszlecenia + "', '" + klientid + "', '" + statusid + "')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Wprowadziłeś poprawnie nowe zlecenie");
            con.Close();

            Console.ReadKey();
        }
    

   
        public void EditJob()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("Dla zlecenia o jakim ID chcesz wyedytować dane? ");
            string idedit;
            idedit = Console.ReadLine();
            Console.WriteLine("Jakie dane chcesz wyedytować? ");
            Console.WriteLine("1. Opis ");
            Console.WriteLine("2. Data złożenia ");
            Console.WriteLine("3. Data wykonania ");
            Console.WriteLine("4. Status ");

            int optedit = int.Parse(Console.ReadLine());

            switch (optedit)
            {
                case 1:
                    string eopiszlecenia;
                    eopiszlecenia = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zlecenie SET opis_zlecenia = ('" + eopiszlecenia + "')  WHERE zlecenie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 2:
                    string edatazlecenia;
                    edatazlecenia = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zlecenie SET data_zlozenia = ('" + edatazlecenia + "')  WHERE zlecenie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 3:
                    string edatawykonania;
                    edatawykonania = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zlecenie SET data_wykonania = ('" + edatawykonania + "')  WHERE zlecenie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 4:
                    string estatuszlecenia;
                    estatuszlecenia = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zlecenie SET status_zlecenia = ('" + estatuszlecenia + "')  WHERE zlecenie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
            }
            Console.ReadKey();
        }
    
   
        public void SearchJob()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            con.Open();
        WyszukajStart:
            Console.WriteLine("W jaki sposób chcesz wyszukiwać?");
            Console.WriteLine("1.Wyszukaj wszystkie zlecenia");
            Console.WriteLine("2.Wyszukaj zlecenia po dacie złożenia");
            Console.WriteLine("3.Wróć do menu");
            int searchopt1 = int.Parse(Console.ReadLine());

            switch (searchopt1)
            {
                case 1:
                    using (SqlCommand cmdd = new SqlCommand("SELECT zlecenie_id, opis_zlecenia, data_zlozenia, data_wykonania, status_zlecenia from zlecenie", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int zlecenie_id = reader.GetInt32(0);
                                string opis_zlecenia = reader.GetString(1);
                                DateTime data_zlozenia = reader.GetDateTime(2);
                                DateTime data_wykonania = reader.GetDateTime(3);
                                string status_zlecenia = reader.GetString(4);


                                Console.WriteLine($"{zlecenie_id} {opis_zlecenia} {data_zlozenia} {data_wykonania} {status_zlecenia}");

                            }
                        }
                    }
                    goto WyszukajStart;

                case 2:
                    Console.WriteLine("Wprowadź datę:");
                    string datasearch;
                    datasearch = Console.ReadLine();
                    using (SqlCommand cmdd = new SqlCommand("SELECT zlecenie_id, opis_zlecenia, data_zlozenia, data_wykonania, status_zlecenia from zlecenie WHERE data_zlozenia=('" + datasearch + "')", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int zlecenie_id = reader.GetInt32(0);
                                string opis_zlecenia = reader.GetString(1);
                                DateTime data_zlozenia = reader.GetDateTime(2);
                                DateTime data_wykonania = reader.GetDateTime(3);
                                string status_zlecenia = reader.GetString(4);


                                Console.WriteLine($"{zlecenie_id} {opis_zlecenia} {data_zlozenia} {data_wykonania} {status_zlecenia}");

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