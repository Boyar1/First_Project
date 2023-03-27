using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Threading;

namespace Serwis
{
    class Serwis
    {
        static void Main(string[] args)
        {

            //Połączenie do serwera SQL
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            SqlCommand cmd;
            //odwołania do wszystkich klas

            Cennik newcennik = new Cennik();

            Urzadzenia newdevice = new Urzadzenia();
            
            Zamowienia neworder = new Zamowienia();
            
            Naprawa newrepair = new Naprawa();
            
            Zlecenie newjob = new Zlecenie();
           
            Klient newclient = new Klient();
           

            //LOGOWANIE           
            String loggedAs = null;
            con.Open();
            while (loggedAs == null)
            {
                Console.Write("Podaj nazwę użytkownika: ");
                String nazwaUzytkownika = Console.ReadLine();
                using (SqlCommand cmdd = new SqlCommand("SELECT login, haslo from pracownik", con))
                {
                    using (SqlDataReader reader = cmdd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String login = reader.GetString(0);
                            String haslo = reader.GetString(1);
                            if (nazwaUzytkownika.Equals(login))
                            {
                                Console.Write("Podaj hasło: ");
                                String password = Console.ReadLine();
                                if (password.Equals(haslo))
                                {
                                    Console.WriteLine("Pomyślnie zalogowano.");
                                    loggedAs = login;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Hasło niepoprawne!\n-----------------------------------------");
                                    break;
                                }

                            }

                        }
                        //Console.WriteLine("Podany użytkownik nie istnieje.\n-----------------------------------------");
                    }
                }
            }
            con.Close();


        Start:

            Console.WriteLine("Witaj w naszym systemie który wesprze Cię w prowadzeniu Serwisu komputerowego!  ");
            Console.WriteLine("Wybierz sekcję do której chcesz przejść (wpisując cyfrę widoczną przy nazwie)");
            Console.WriteLine("1.Ewidencja klientów");
            Console.WriteLine("2.Ewidencja zleceń");
            Console.WriteLine("3.Ewidencja napraw");
            Console.WriteLine("4.Ewidencja zamówień");
            Console.WriteLine("5.Ewidencja urządzeń");
            Console.WriteLine("6.Cenniki");
            Console.WriteLine("7.Wyjdź z programu");
            //zmienna do wybierania opcji menu
            int menuopt = int.Parse(Console.ReadLine());
            //menu aplikacji
            switch (menuopt)
            {
                
                case 1:
                StartKlient:
                    Console.WriteLine("Jakich akcji chciałbyś dokonać?");
                    Console.WriteLine("1.Dodanie nowego klient");
                    Console.WriteLine("2.Edycja danych klienta");
                    Console.WriteLine("3.Wyszukanie klienta");
                    Console.WriteLine("4.Powrót do menu");
                    int klientopt = int.Parse(Console.ReadLine());
                    switch (klientopt)
                    {
                        case 1:
                            newclient.AddClient();
                            goto StartKlient;
                        case 2:
                            newclient.EditClient();
                            goto StartKlient;
                        case 3:
                            newclient.SearchClient();
                            goto StartKlient;
                        case 4:
                            goto Start;
                    }
                    break;
                case 2:
                StartZlecenia:
                    Console.WriteLine("Jakich akcji chciałbyś dokonać?");
                    Console.WriteLine("1.Dodanie nowego zlecenia");
                    Console.WriteLine("2.Edycja zlecenia");
                    Console.WriteLine("3.Wyszukanie zlecenia");
                    Console.WriteLine("4.Powrót do menu");
                    int zleceniaopt = int.Parse(Console.ReadLine());
                    switch (zleceniaopt)
                    {
                        case 1:
                            newjob.AddJob();
                            goto StartZlecenia;
                        case 2:
                            newjob.EditJob();
                            goto StartZlecenia;
                        case 3:
                            newjob.SearchJob();
                            goto StartZlecenia;
                        default:
                            goto Start;
                    }
                    break;

                case 3:
                StartNaprawa:
                    Console.WriteLine("Jakich akcji chciałbyś dokonać?");
                    Console.WriteLine("1.Dodanie nowej naprawy");
                    Console.WriteLine("2.Edycja danych naprawy");
                    Console.WriteLine("3.Wyszukanie naprawy");
                    Console.WriteLine("4.Powrót do menu");
                    int naprawaopt = int.Parse(Console.ReadLine());
                    switch (naprawaopt)
                    {
                        case 1:
                            newrepair.AddRepair();
                            goto StartNaprawa;
                        case 2:
                            newrepair.EditRepair();
                            goto StartNaprawa;
                        case 3:
                            newrepair.SearchRepair();
                            goto StartNaprawa;
                        case 4:
                            goto Start;
                    }
                    break;
                case 4:
                StartZamowienie:
                    Console.WriteLine("Jakich akcji chciałbyś dokonać?");
                    Console.WriteLine("1.Dodanie nowego zamówienia");
                    Console.WriteLine("2.Edycja zamówienia");
                    Console.WriteLine("3.Wyszukanie zamówienia");
                    Console.WriteLine("4.Powrót do menu");
                    int zamowienieopt = int.Parse(Console.ReadLine());
                    switch (zamowienieopt)
                    {
                        case 1:
                            neworder.AddOrder();
                            goto StartZamowienie;
                        case 2:
                            neworder.EditOrder();
                            goto StartZamowienie;
                        case 3:
                            neworder.SearchOrder();
                            goto StartZamowienie;
                        case 4:
                            goto Start;
                    }
                    break;

                case 5:
                StartUrzadzenie:
                    Console.WriteLine("Jakich akcji chciałbyś dokonać?");
                    Console.WriteLine("1.Dodanie nowego urządzenia");
                    Console.WriteLine("2.Edycja danych urządzenia");
                    Console.WriteLine("3.Wyszukanie urządzenia");
                    Console.WriteLine("4.Powrót do menu");
                    int urzadzeniaopt = int.Parse(Console.ReadLine());
                    switch (urzadzeniaopt)
                    {
                        case 1:
                            newdevice.AddDevice();
                            goto StartUrzadzenie;
                        case 2:
                            newdevice.EditDevice();
                            goto StartUrzadzenie;
                        case 3:
                            newdevice.SearchDevice();
                            goto StartUrzadzenie;
                        case 4:
                            goto Start;
                    }
                    break;
                    case 6:
                    Console.WriteLine("Co chcesz zrobić?\n1 - Wyświetl cennik\n2 - Dodaj pozycję\n3 - Usuń pozycję");
                    String cennikWybor = Console.ReadLine();
                    switch (cennikWybor)
                    {
                        case "1":
                            newcennik.pokazCennik();
                            break;
                        case "2":
                            newcennik.dodajCennik();
                            break;
                        case "3":
                            newcennik.usunCennik();
                            break;
                    }
                    break;
                default:

                    Environment.Exit(0);
                    break;
            }

            //editclient.SearchClient();
        }
    }
}
