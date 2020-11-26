using DAL.Interfaces;
using System;
using System.Data.SqlClient;
using DTO;

namespace DAL.Concrete
{
    public class BasketDal : IBasketDal
    {
        private string connectionString;

        public BasketDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddToBasket(BasketDTO newelem)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Basket (Title, Price) output INSERTED.BasketID values (@Title, @Price)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Title", newelem.Title);
                comm.Parameters.AddWithValue("@Price", newelem.Price);
                conn.Open();

                newelem.BasketID = Convert.ToInt32(comm.ExecuteScalar());
            }
        }
    }
}
