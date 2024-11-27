using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdioNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. read all data\n2. read data by ID\n3. insert new data\n4. Modify Data\n5. Delete data by id\n6. Exit ");
            
            ConnectedEnviroment connectedEnviroment = new ConnectedEnviroment();
            
            while (true)
            {
                Console.WriteLine("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        connectedEnviroment.ReadData();
                        break;
                    case 2:
                        Console.WriteLine("enter id of record");
                        int id = Convert.ToInt32(Console.ReadLine());
                        connectedEnviroment.ReadDataById(id);
                        break;
                    case 3:
                        int idForInsert, ValueForId;
                        Console.WriteLine("Enter ID for new record: ");
                        idForInsert = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter value for new record: ");
                        ValueForId = Convert.ToInt32(Console.ReadLine());
                        connectedEnviroment.AddData(idForInsert, ValueForId);

                        break;
                    case 4:
                        int idForUpdate, ValueForIdUpdate;
                        Console.WriteLine("Enter ID for record to update: ");
                        idForUpdate = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter value for record to update: ");
                        ValueForIdUpdate = Convert.ToInt32(Console.ReadLine());
                        connectedEnviroment.ModifyData(idForUpdate, ValueForIdUpdate);
                        break;
                    case 5:
                        int idForDeletion;
                        Console.WriteLine("Enter ID for record to delete: ");
                        idForDeletion = Convert.ToInt32(Console.ReadLine());
                        connectedEnviroment.DeleteData(idForDeletion);
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using the app");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            
            //Console.ReadKey();
        }
    }
}
