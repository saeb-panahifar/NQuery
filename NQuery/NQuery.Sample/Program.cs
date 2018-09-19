using System;

namespace NQuery.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryResult = Query
                .From<Customer>().Where(a => a.Id == 10 && a.LastName == "paul");
               


            Console.WriteLine(queryResult.ToString());

            Console.ReadLine();
        }
    }
}
