using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Data
{
    public class ShoppingCartData : Data
    {
        public static List<Cart> GetCart()
        {
            //create list to store all records from Cart
            List<Cart> cart = new List<Cart>();

            //connect to database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT p.Id, p.Image, p.Title, p.Description, p.Price, c.Quantity
                                FROM Product p, CartTest c WHERE p.Id = c.Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //store each record as Cart object
                    Cart item = new Cart()
                    {
                        Id = (int)reader["Id"],
                        Image = (string)reader["Image"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        Price = (double)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    };
                    cart.Add(item);
                }
            }
            //return list to controller
            return cart;
        }
        public static void RemoveItem(int id)
        {
            //connect to database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //delete record where the id matches
                string sql = @"DELETE FROM CartTest WHERE Id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conn);

                //check output to confirm 1 record deleted
                int noAffectedRows = cmd.ExecuteNonQuery();
                Debug.WriteLine(noAffectedRows);
            }
        }

        public static void UpdateItem(int id)
        {
            //connect to database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //update record where the id matches
                string sql = @"UPDATE FROM CartTest WHERE Id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conn);

                //check output to confirm 1 record deleted
                int noAffectedRows = cmd.ExecuteNonQuery();
                Debug.WriteLine(noAffectedRows);
            }
        }
    }
}
