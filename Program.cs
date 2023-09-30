using System.Xml.Schema;

namespace ADO.NetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ADO.Intro");
            //CustomarOperations.CreateDatabase();
            //CustomarOperations.CreateTable();
            //CustomarOperations.InsertData();
            //CustomarOperations.Display();
            //CustomerDetails details = new CustomerDetails();
            //details.Name = "Test";
            //details.City = "Panjab";
            //details.Phone = 274589386;
            //CustomarOperations.InsertUsingStoreProcedure(details);

            CustomerDetails details = new CustomerDetails();
            CustomarOperations.DisplayUsingProcedure(details);

        }
    }
}