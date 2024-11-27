using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AdioNet
{
    public class ConnectedEnviroment
    {
        SqlConnection connection;
        SqlCommand cmd;

        string conString = "Data Source=LIN-5CG4372MXS\\SQLEXPRESS;Integrated Security=True;Initial Catalog=EmpDb";
        public void AddData(int a  , int b) {

            connection = new SqlConnection(conString);
            string sql = $"insert into Temptable values ({a} , {b})";
            connection.Open();
            cmd = new SqlCommand(sql, connection);
            int count = cmd.ExecuteNonQuery(); 
            if (count > 0)
            {
                Console.WriteLine("Data inserted successfully");
            }
            else
            {
                Console.WriteLine("Data insertion failed");
            }
            connection.Close();
        }//insert
        public void ModifyData(int a , int b) {
        connection = new SqlConnection(conString);
            string sql = $"update TempTable set did = {b} where ID ={a} ";
            connection.Open();
            cmd = new SqlCommand(sql, connection);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("Data updated successfully");
            }
            else
            {
                Console.WriteLine("Data updation failed");
            }
            connection.Close();
        }
        //update
        public void DeleteData(int id) { 
                connection = new SqlConnection(conString);
            string sql = $"delete from TempTable where Id = {id}";
           
            // show data before deletion
            Console.WriteLine("deleted the following record");
            this.ReadDataById(id);
            connection.Open();


            cmd = new SqlCommand(sql, connection);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("Data deleted successfully");
            }
            else
            {
                Console.WriteLine("Data deletion failed");
            }
            connection.Close();
        }//delete
        public void ReadDataById(int a) { 
            connection = new SqlConnection(conString);
            string sql = $"select * from TempTable where ID = {a}";
            connection.Open();
            cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Displaying All records\nID\tValue\n");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }
            connection.Close();
        }
        public void ReadData() { 
           

        connection = new SqlConnection(conString);
            string sql = "select * from TempTable";
            connection.Open();
            cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Displaying All records\nID\tValue\n");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }
            connection.Close();

        }//select
    }
}
