using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class VideogameManager
    {

        public static string DatabaseConesso = "Data Source=localhost;Initial Catalog=db-videogames-query;Integrated Security=True";

        public static void InserisciVideogame(string name, string overview, DateTime release_date, DateTime create_at, DateTime update_at, int software_house_id)
        {
            Videogame NuovoGioco = new Videogame(name, overview, release_date, create_at, update_at, software_house_id);
            using SqlConnection eseguitoConessione = new SqlConnection(DatabaseConesso);

            try
            {
                eseguitoConessione.Open();
                string query = "INSERT INTO videogames(name , overview , release_date , created_at ,updated_at , software_house_id) VALUES (@name , @overview , @release_date , @create_at , @update_at , @software_house_id)";
                using SqlCommand cmd = new SqlCommand(query, eseguitoConessione);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@overview", overview));
                cmd.Parameters.Add(new SqlParameter("@release_date", release_date));
                cmd.Parameters.Add(new SqlParameter("@create_at", create_at));
                cmd.Parameters.Add(new SqlParameter("@update_at", update_at));
                cmd.Parameters.Add(new SqlParameter("@software_house_id", software_house_id));

                int efect = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                eseguitoConessione.Close();
            }
        }
        public static Videogame CercaVideogame(int id)
        {

            using SqlConnection eseguitoConessione = new SqlConnection(DatabaseConesso);
            Videogame videogameFound = null;
            try
            {
                eseguitoConessione.Open();
                string query = "SELECT * FROM videogames WHERE id= @id";
                using SqlCommand cmd = new SqlCommand(query, eseguitoConessione);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                //chat
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["name"].ToString();
                    string overview = reader["overview"].ToString();
                    DateTime release_date = Convert.ToDateTime(reader["release_date"]);
                    DateTime create_at = Convert.ToDateTime(reader["release_date"]);
                    DateTime update_at = Convert.ToDateTime(reader["release_date"]);
                    int software_house_id = Convert.ToInt32(reader["software_house_id"]);

                    videogameFound = new Videogame(name, overview, release_date, create_at, update_at, software_house_id);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                eseguitoConessione.Close();
            }

            return videogameFound;

        }

        public static void EliminaVideogames(int id)
        {
            string query = "DELETE FROM videogames WHERE id= @id";
            using SqlConnection eseguitoConessione = new SqlConnection(DatabaseConesso);
            try
            {
                eseguitoConessione.Open();
                using SqlCommand cmd = new SqlCommand(query, eseguitoConessione);
                cmd.Parameters.Add(new SqlParameter("@id", id));

                int Eleminazione = cmd.ExecuteNonQuery();
                if (Eleminazione > 0)
                {
                    Console.WriteLine("eliminazione ggioco avvenuta con sucesso ");
                }
                else
                {
                    Console.WriteLine("ggioco non trovato ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                eseguitoConessione.Close();
            }
        }
    }
}
