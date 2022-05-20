using GestioneSpese.Entita;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Repository
{
    internal static class RepositorySpeseDisconnect
    {  
        
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static void UpdateRowSpese()
        {
          
            DataSet personalDB = new DataSet();

            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non Connessi al DB");
                conn.Close();
                Console.WriteLine("Connessione chiusa");


                SqlDataAdapter personaAdapter = InizializzaAdapter(conn);
                personaAdapter.Fill(personalDB, "SpeseDT");
                conn.Close();
                Console.WriteLine("Connessione chiusa");

                Console.WriteLine("Inserisci ID del Spese");
                int idDaAggiornare;
                while (!int.TryParse(Console.ReadLine(), out idDaAggiornare))
                {
                    Console.WriteLine("Riprova. Insersci un numero.");
                };


                DataRow rigaDaAggiornare = personalDB.Tables["Spese"].Rows.Find(idDaAggiornare);
                if (rigaDaAggiornare != null)
                {
                    Console.WriteLine("Scegli tra colonne che vuoi aggiornare: 1 =>[Data] \t 2 => [Descrivere] \t 3 => [Utente] \t 4 => [Importo] \t 5 => [Approvato] \t 6 => [idCategorie]");
                    int scelta;
                    while (!int.TryParse(Console.ReadLine(), out scelta))
                    {
                        Console.WriteLine("Riprova. Insersci un numero.");
                    };

                    bool q = false;
                    do
                    {
                        switch (scelta)
                        {
                            case 1:
                                Console.WriteLine("Descrivere Spese");
                                rigaDaAggiornare["Descrizione"] = Console.ReadLine();
                                q = true;
                                break;
                            case 2:
                                Console.WriteLine("inserire Data");
                                DateTime data_sc = DateTime.Parse(Console.ReadLine());
                                rigaDaAggiornare["Data"] = data_sc;
                                q = true;
                                break;
                            case 3:
                                Console.WriteLine("Inserire il nome di Utente");
                                rigaDaAggiornare["Utente"] = Console.ReadLine();
                                q = true;
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("Comando sconosciuto");
                                q = true;
                                break;

                              }

                    } while (q == false);


     
                    personaAdapter.Update(personalDB, "SpeseDT");
                    Console.WriteLine("");

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }




        public static void DeleteRowSpese()
        {

            DataSet personalDB = new DataSet();

            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non Connessi al DB");
                conn.Close();
                Console.WriteLine("Connessione chiusa");

                SqlDataAdapter personaAdapter = InizializzaAdapter(conn);
                personaAdapter.Fill(personalDB, "SpeseDT");
                conn.Close();
                Console.WriteLine("Connessione chiusa");

                Console.WriteLine("Inserisci ID del Spese");
                int idDaEliminare;
                while (!int.TryParse(Console.ReadLine(), out idDaEliminare))
                {
                    Console.WriteLine("Riprova. Insersci un numero.");
                };

                DataRow rigaDaEliminare = personalDB.Tables["SpeseDT"].Rows.Find(idDaEliminare);

                if (rigaDaEliminare != null)
                {
                    rigaDaEliminare.Delete();
                }

                personaAdapter.Update(personalDB, "SpeseDT");
                Console.WriteLine("");

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }







            public static void ElencoSpeseDiUnUtenteDisconnect() {

            DataSet personalDB = new DataSet();

            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non Connessi al DB");

                SqlDataAdapter personalAdapter = InizializzaAdapter(conn);

                 personalAdapter.Fill(personalDB, "SpeseDT");
                 conn.Close();
                 Console.WriteLine("Connessione chiusa");

                string utente_nome = Console.ReadLine();

                foreach (DataRow riga1 in personalDB.Tables["SpeseDT"].Rows)
                {
                    if (riga1["Utente"].Equals(utente_nome)) { 

                        Console.WriteLine($"{riga1["Id"]} - {riga1["Data"]} - {riga1["Descrizione"]} - {riga1["Utente"]} - {riga1["Importo"]} - {riga1["Approvato"]} - {riga1["CategoriaId"]}");
                }
           }
      }



            catch (SqlException ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
         
        }

        private static SqlDataAdapter InizializzaAdapter(SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            //FILL
            adapter.SelectCommand = new SqlCommand("select * from Spese", conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //UPDATE
            adapter.UpdateCommand = GeneraUpdateCommand(conn);
            //DELETE
            adapter.DeleteCommand = GeneraDeleteCommand(conn);

            return adapter;
        }


        private static SqlCommand GeneraUpdateCommand(SqlConnection conn)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Update Spese set Data = @dataSpese, Descrizione = @descrizioneSpese, Utente = @utenteSpese, Importo = @importoSpese, CategoriaId=@idCategorie  where Id = @idSpese";
            command.Parameters.Add(new SqlParameter("@idSpese", SqlDbType.Int, 0, "Id"));            
            command.Parameters.Add(new SqlParameter("@dataSpese", SqlDbType.DateTime, 0, "Data"));
            command.Parameters.Add(new SqlParameter("@descrizioneSpese", SqlDbType.VarChar, 500, "Descrizione"));
            command.Parameters.Add(new SqlParameter("@utenteSpese", SqlDbType.VarChar, 100, "Utente"));
            command.Parameters.Add(new SqlParameter("@importoSpese", SqlDbType.Decimal, 50, "Importo"));
            command.Parameters.Add(new SqlParameter("@idCategorie", SqlDbType.VarChar, 50, "CategoriaId"));


            return command;
        }



        private static SqlCommand GeneraDeleteCommand(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from Spese where Id = @idSpese";
            command.Parameters.Add(new SqlParameter("@idSpese", SqlDbType.Int, 0, "Id"));

            return command;
        }


    }
}
