using GestioneSpese.Entita;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Repository
{
    internal  static class RepositorySpeseConnect
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

         public static void ConnectionDemo()
        {

            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            connessione.Open();
            if (connessione.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connessi al DB");
            }
            else
            {
                Console.WriteLine("Non Connessi al DB");
            }

            connessione.Close();
        }




        public static void DataReaderSpese()
        {

            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();
                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non Connessi al DB");
                }

                string query = "select * from Spese order by Id ASC";

                SqlCommand commando = new SqlCommand();
                commando.Connection = connessione;
                commando.CommandType = System.Data.CommandType.Text;
                commando.CommandText = query;

                SqlDataReader reader = commando.ExecuteReader();

                Console.WriteLine("Spese");
                while (reader.Read())
                {

                    var id = reader.GetInt32(0);
                     var data = reader.GetDateTime(1);
                    var descrizione = reader.GetString(2);
                    var utente = reader.GetString(3);
                    var importo = reader.GetDecimal(4);
                    var approvato = reader.GetBoolean(5);
                    var idCategorie = reader.GetInt32(6);

                    Console.WriteLine($"{id} - {data} - {descrizione} - {utente} - {importo} - {approvato} - {idCategorie}");

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("-----Premi un tasto------ ");
                Console.ReadKey();
            }

        }



        public static void InsertSpese()
        {

            using SqlConnection connessione = new SqlConnection(connectionStringSQL);

            try
            {
                connessione.Open();
                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non Connessi al DB");
                }
    
      

           Console.WriteLine("inserire Data di Spese");
           DateTime data_sc = DateTime.Parse(Console.ReadLine());
           Console.WriteLine("inserire la Descrizione di Spese");
           string descr = Console.ReadLine();
           Console.WriteLine("Inserire il utente di Spese");
           string utente = Console.ReadLine();
           Console.WriteLine("Inserire importo di Spese");
              decimal importo;//= int.Parse(Console.ReadLine());
                while (!(decimal.TryParse(Console.ReadLine(), out importo)))
                {
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                }

           Console.WriteLine("Inserire se e' approvato della Spese");
                int approvato = int.Parse(Console.ReadLine());
                bool  approvato_bbol= ApprovatoNumber(approvato);


                Console.WriteLine("Inserire ID di Categoria");
                int idCategorie;
                while (!(int.TryParse(Console.ReadLine(), out idCategorie)))
                {
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                }

              SqlCommand insertCommand = connessione.CreateCommand();
          if(approvato != 0)
                {
                Console.WriteLine("Inserimento di Spese e' falito");
                }
                else {
             
                    string insertSQL = $"insert into Spese values(@dataSpese, @descrizioneSpese, @utenteSpese,@importoSpese,@approvatoSpese,@idCategorie)";
                    insertCommand.CommandText = insertSQL;
       
           insertCommand.Parameters.AddWithValue("@dataSpese", data_sc);   
           insertCommand.Parameters.AddWithValue("@descrizioneSpese", descr);
           insertCommand.Parameters.AddWithValue("@utenteSpese", utente);
           insertCommand.Parameters.AddWithValue("@importoSpese", importo);
            insertCommand.Parameters.AddWithValue("@approvatoSpese", approvato_bbol);
            insertCommand.Parameters.AddWithValue("@idCategorie", idCategorie);

 }
                
                  
                

                int righeInserite = insertCommand.ExecuteNonQuery();


           if (righeInserite != 1)
           {
               Console.WriteLine("Si è verificato un problema nell'inserimento del spese");
           }
           else
           {
               Console.WriteLine("Spese aggiuto correttamente");
           }

       }

       catch (Exception ex)
       {
           Console.WriteLine($"Errore generico: {ex.Message}");
       }
       finally
       {
           connessione.Close();
           Console.WriteLine("-----Premi un tasto------ ");
           Console.ReadKey();
       }
   }

        public static void ElencoSpeseDiUnUtenteConect()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);

            try
            {
                connessione.Open();
                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non Connessi al DB");
                }

                Console.WriteLine("Inserire il utente di Spese");
                string utente = Console.ReadLine();


                 string query = "select * from Spese where Utente = @utenteSpese";
                SqlCommand commando = connessione.CreateCommand();
                commando.Connection = connessione;
                commando.CommandType = System.Data.CommandType.Text;
                commando.CommandText = query;

                commando.Parameters.AddWithValue("@utenteSpese", utente);


                SqlDataReader reader = commando.ExecuteReader();

                Console.WriteLine("Spese");
                while (reader.Read())
                {

                    var id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var descrizione = reader.GetString(2);
                    var utente_s = reader.GetString(3);
                    var importo = reader.GetDecimal(4);
                    var approvato = reader.GetBoolean(5);
                    var idCategorie = reader.GetInt32(6);

                    Console.WriteLine($"{id} - {data} - {descrizione} - {utente_s} - {importo} - {approvato} - {idCategorie}");
                    }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("-----Premi un tasto------ ");
                Console.ReadKey();

            }
        }


        public static void SpesaApprovata()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);

            try
            {
                connessione.Open();
                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non Connessi al DB");
                }


                 int approvato = int.Parse(Console.ReadLine());
                bool approvato_bbol = ApprovatoNumber(approvato);


                string query = "select * from Spese where Approvato = @approvatoBool and Approvato not in (select Approvato from Spese where Approvato = 1 )";
                SqlCommand commando = connessione.CreateCommand();
                commando.Connection = connessione;
                commando.CommandType = System.Data.CommandType.Text;
                commando.CommandText = query;



                commando.Parameters.AddWithValue("@approvatoBool", approvato_bbol);

                SqlDataReader reader = commando.ExecuteReader();

                Console.WriteLine("Spese");
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var descrizione = reader.GetString(2);
                    var utente_s = reader.GetString(3);
                    var importo = reader.GetDecimal(4);
                    var approvato1 = reader.GetBoolean(5);
                    var idCategorie = reader.GetInt32(6);

                    Console.WriteLine($"{id} - {data} - {descrizione} - {utente_s} - {importo} - {approvato1} - {idCategorie}");


                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("-----Premi un tasto------ ");
                Console.ReadKey();

            }
        }

            public static void SpesaTotalePerUnaCategoria()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);

            try
            {
                connessione.Open();
                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non Connessi al DB");
                }

                string query = "select c.Categoria, SUM(s.Importo) as 'Somma' from Spese s, Categorie c  where(c.Id = s.CategoriaId) group by c.Categoria";
                SqlCommand commando = connessione.CreateCommand();
                commando.Connection = connessione;
                commando.CommandType = System.Data.CommandType.Text;
                commando.CommandText = query;

                SqlDataReader reader = commando.ExecuteReader();

                Console.WriteLine("Spese");
                while (reader.Read())
                {
                    var categoria = reader.GetString(0);
                    var importo = reader.GetDecimal(1);

                    Console.WriteLine($"{categoria} - {importo}");

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("-----Premi un tasto------ ");
                Console.ReadKey();

            }
        }


            public static bool ApprovatoNumber(int n)
        {
            int approvato = n;
            bool approvato_bbol;
            if (approvato == 0)
            {
                return approvato_bbol = true;
            }
            else 
            {
              return  approvato_bbol = false;
            }
        }



    }
}
