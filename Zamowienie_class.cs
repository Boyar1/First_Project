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
    class Zamowienia
    {

        public void AddOrder()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("W celu dodania nowego zamówienia należy podać następujące dane:");

            Console.WriteLine("Nazwę zamawianego produktu: ");
            string zamowienienazwa;
            zamowienienazwa = Console.ReadLine();

            Console.WriteLine("Ilość produktów: ");
            string zamowienieilosc;
            zamowienieilosc = Console.ReadLine();

            Console.WriteLine("Koszt jednostkowy: ");
            string zamowieniekoszt;
            zamowieniekoszt = Console.ReadLine();

            Console.WriteLine("Koszt całkowity: ");
            string zamowieniecalkowity;
            zamowieniecalkowity = Console.ReadLine();

            Console.WriteLine("Data składania zamówienia: ");
            string zamowieniedata;
            zamowieniedata = Console.ReadLine();

            Console.WriteLine("ID Pracownika wykonującego zamówienie: ");
            string zampracownikid;
            zampracownikid = Console.ReadLine();

            Console.WriteLine("ID zamówienia: ");
            string zamowienieid;
            zamowienieid = Console.ReadLine();

            con.Open();
            cmd = new SqlCommand("insert into zamowienie values ('" + zamowieniedata + "', '" + zamowieniecalkowity + "', '" + zampracownikid + "', '" + zamowienieid + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            cmd = new SqlCommand("insert into zamowienie_szczegoly values ('" + zamowienienazwa + "', '" + zamowienieilosc + "', '" + zamowieniekoszt + "', '" + zamowienieid + "')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Wprowadziłeś poprawnie nową naprawę");
            con.Close();

            Console.ReadKey();
        }
    

        public void EditOrder()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            Console.WriteLine("Dla zamówienia o jakim ID chcesz wyedytować dane? ");
            string idedit;
            idedit = Console.ReadLine();
            Console.WriteLine("Jakie dane chcesz wyedytować? ");
            Console.WriteLine("1. Nazwę produktu ");
            Console.WriteLine("2. Ilość zamawianych produktów ");
            Console.WriteLine("3. Koszt jednostkowy produktu");
            Console.WriteLine("4. Koszt całkowity");
            Console.WriteLine("5. Data zamówienia ");

            int optedit = int.Parse(Console.ReadLine());

            switch (optedit)
            {
                case 1:
                    string ezamowieninazwa;
                    ezamowieninazwa = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zamowienie_szczegoly SET nazwa = ('" + ezamowieninazwa + "')  WHERE zamowienie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 2:
                    string ezamowienieilosc;
                    ezamowienieilosc = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zamowienie_szczegoly SET ilosc = ('" + ezamowienieilosc + "')  WHERE zamowienie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 3:
                    string ezamowieniekoszt;
                    ezamowieniekoszt = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zamowienie_szczegoly SET koszt_jednostkowy = ('" + ezamowieniekoszt + "')  WHERE zamowienie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 4:
                    string ezamowieniecalkowity;
                    ezamowieniecalkowity = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zamowienie SET koszt_calkowity = ('" + ezamowieniecalkowity + "')  WHERE zlecenie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
                case 5:
                    string ezamowieniedata;
                    ezamowieniedata = Console.ReadLine();
                    con.Open();
                    cmd = new SqlCommand("UPDATE zamowienie SET zamowienie_data = ('" + ezamowieniedata + "')  WHERE zlecenie_id = ('" + idedit + "')", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Edycja zakończona sukcesem");
                    Console.WriteLine("");
                    break;
            }
            Console.ReadKey();
        }
    

        public void SearchOrder()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;

            con.Open();
        WyszukajStart:
            Console.WriteLine("W jaki sposób chcesz wyszukiwać?");
            Console.WriteLine("1.Wyszukaj wszystkie zamówienia");
            Console.WriteLine("2.Wyszukaj zamówienia po dacie");
            Console.WriteLine("3.Wróć do menu");
            int searchopt1 = int.Parse(Console.ReadLine());

            switch (searchopt1)
            {
                case 1:
                    using (SqlCommand cmdd = new SqlCommand("SELECT zamowienie_szczegoly.nazwa, zamowienie_szczegoly.ilosc, zamowienie_szczegoly.koszt_jednostkowy, zamowienie.koszt_calkowity, zamowienie.zamowienie_data FROM zamowienie_szczegoly INNER JOIN zamowienie ON zamowienie_szczegoly.zamowienie_id=zamowienie.zamowienie_id", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String zamnazwa = reader.GetString(0);
                                int zamilosc = reader.GetInt32(1);
                                Decimal zamkoszt = reader.GetDecimal(2);
                                Decimal zamkosztcal = reader.GetDecimal(3);
                                DateTime zamdata = reader.GetDateTime(4);


                                Console.WriteLine($"{zamnazwa} Ilość: {zamilosc} Koszt sztuka: {zamkoszt} Koszt całkowity: {zamkosztcal} {zamdata}");

                            }
                        }
                    }
                    goto WyszukajStart;

                case 2:
                    Console.WriteLine("Wprowadź datę:");
                    string datasearch;
                    datasearch = Console.ReadLine();
                    using (SqlCommand cmdd = new SqlCommand("SELECT zamowienie_szczegoly.nazwa, zamowienie_szczegoly.ilosc, zamowienie_szczegoly.koszt_jednostkowy, zamowienie.koszt_calkowity, zamowienie.zamowienie_data \r\nFROM zamowienie_szczegoly \r\nINNER JOIN zamowienie ON zamowienie_szczegoly.zamowienie_id=zamowienie.zamowienie_id\r\nWHERE zamowienie.zamowienie_data LIKE ('" + datasearch + "')", con))
                    {
                        using (SqlDataReader reader = cmdd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String zamnazwa = reader.GetString(0);
                                int zamilosc = reader.GetInt32(1);
                                Decimal zamkoszt = reader.GetDecimal(2);
                                Decimal zamkosztcal = reader.GetDecimal(3);
                                DateTime zamdata = reader.GetDateTime(4);


                                Console.WriteLine($"{zamnazwa} Ilość: {zamilosc} Koszt sztuka: {zamkoszt} Koszt całkowity: {zamkosztcal} {zamdata}");

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
