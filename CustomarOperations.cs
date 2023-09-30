using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetDemo
{
    public class CustomarOperations
    {
        public static void CreateDatabase()
        {
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=master; integrated security=true");
            //writing sql query
            string qurery = "create database Customer";
            SqlCommand cmd = new SqlCommand(qurery,con);
            con.Open();
            cmd.ExecuteNonQuery();
            //display messege
            Console.WriteLine("DatabaseCreate successfully");
            Console.WriteLine("---------------------");
            con.Close();
        }
        public static SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=Customer; integrated security=true");

        public static void CreateTable()
        {
            string query = "Create Table CustomerData(ID int primary key identity(1,1),Name varchar(100),City varchar(50),Phone bigint)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table cteated Successfully");
            Console.WriteLine("-----------------------");
            con.Close();

        }
        public static void InsertData()
        {
            string query = "Insert into CustomerData values('Sireesha','Nellore',9898653647),('uma','Vijayavada',9898657647),('Havi','Ongole',9898753647)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("inserted values Successfully");
            Console.WriteLine("-----------------------");
            con.Close();

        }
        public static void Display()
        {
            using (con)
            {
                CustomerDetails Details  = new CustomerDetails();
                string query = "Select * from CustomerData";
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if(sqlDataReader.HasRows)
                {
                    Console.WriteLine("-------Data------");
                    while(sqlDataReader.Read())
                    {
                        Details.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        Details.Name = Convert.ToString(sqlDataReader["Name"]);
                        Details.City = Convert.ToString(sqlDataReader["City"]);
                        Details.Phone= Convert.ToInt64(sqlDataReader["Phone"]);
                        Console.WriteLine("ID:{0}\n Name:{1}\n City:{2} \n Phone :{3}\n,", Details.ID, Details.Name, Details.City, Details.Phone);
                    }
                }
                con.Close();    
                
            }
        }
        public static void InsertUsingStoreProcedure(CustomerDetails customerDetails)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("Sp_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", customerDetails.Name);
                cmd.Parameters.AddWithValue("@City", customerDetails.City);
                cmd.Parameters.AddWithValue("@Phone", customerDetails.Phone);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted Successfully");
                con.Close();

            }
        }
        public static void DisplayUsingProcedure(CustomerDetails Details)
        {
            using (con)
            {

                SqlCommand cmd = new SqlCommand("Display", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("-------Data------");
                    while (sqlDataReader.Read())
                    {
                        Details.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        Details.Name = Convert.ToString(sqlDataReader["Name"]);
                        Details.City = Convert.ToString(sqlDataReader["City"]);
                        Details.Phone = Convert.ToInt64(sqlDataReader["Phone"]);
                        Console.WriteLine("ID:{0}\n Name:{1}\n City:{2} \n Phone :{3}\n,", Details.ID, Details.Name, Details.City, Details.Phone);
                    }
                }
                con.Close();

            }
        }
    }
}
