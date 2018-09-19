using System;

namespace NQuery.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryResult = Query
                .From<Customer>().Where(a => a.FirstName == "paul".ToUpper() && a.Id > 10); 
               
            Console.WriteLine(queryResult.ToString());

            Console.ReadLine();
        }
    }
}
