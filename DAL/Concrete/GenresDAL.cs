using DTO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
namespace DAL.Concrete
{
    public class GenresDal : IGenreDal
    {
        private string connectionString;

        public GenresDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        string connStr = ConfigurationManager.ConnectionStrings["GamesDB"].ConnectionString;
        public List<GenresDTO> GetAllGenres()
        {
            using (SqlConnection conn = new SqlConnection(this.connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Genres";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<GenresDTO> genres = new List<GenresDTO>();
                while (reader.Read())
                {

                    genres.Add(new GenresDTO
                    {
                        GenreID = (int)reader["GenreID"],
                        GenreName = reader["GenreName"].ToString(),

                    });

                }
                return genres;
            }
        }
    }

}
