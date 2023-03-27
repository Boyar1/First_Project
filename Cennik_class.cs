using System.Data.SqlClient;
using System;




namespace Serwis
{
    class Cennik
    {
        public void pokazCennik()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            con.Open();
            using (SqlCommand cmdd = new SqlCommand("SELECT * from cennik", con))
            {
                using (SqlDataReader reader = cmdd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader.GetString(0) + ": " + reader.GetDecimal(1) + " zł\n");
                    }
                }
            }
            con.Close();
        }

        public void dodajCennik()
        {
            Console.Write("Podaj nazwę nowej uslugi: ");
            String nazwa = Console.ReadLine();
            if (nazwa.Length > 50)
            {
                Console.WriteLine("Podana nazwa jest za długa.\nError 50: ograniczenie długości nazwy do maksymalnie 50 znaków.");
                return;
            }

            Console.Write("Podaj cenę nowej uslugi: ");
            float nowaCena = float.Parse(Console.ReadLine());
            if (nowaCena < 0)
            {
                Console.WriteLine("Cena nie może być ujemna.");
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            String insert = "INSERT INTO cennik VALUES('" + nazwa + "', " + nowaCena.ToString() + ");";
            con.Open();
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Close();

        }

        public void usunCennik()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3EA72AG\\SQLEXPRESS;Initial Catalog=SerwisKomputerowy;Integrated Security=True;");
            con.Open();
            using (SqlCommand cmdd = new SqlCommand("SELECT * from cennik", con))
            {
                using (SqlDataReader reader = cmdd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write("ID: " + reader.GetInt32(0).ToString() + "\nNazwa usługi: " + reader.GetString(1) + "\nCena: " + reader.GetDecimal(1) + " zł\n\n");
                    }

                    Console.Write("Którą pozycję z listy chcesz usunąć? - podaj ID\nID do usunięcia: ");
                    int idDelete = int.Parse(Console.ReadLine());
                    String delete = "DELETE FROM cennik WHERE cennik_ID=" + idDelete;
                    SqlCommand cmd = new SqlCommand(delete, con);
                    cmd.ExecuteNonQuery();
                }
            }
            con.Close();
        }
    }
}