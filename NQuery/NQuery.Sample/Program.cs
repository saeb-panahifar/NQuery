using System;

namespace NQuery.Sample
{

    class Program
    {
        static void Main(string[] args)
        {
            var queryResult = Query
                .From<Customer>()
                .SelectAll()
                .Where(a => a.Id == 10);

            Console.WriteLine(queryResult.ToString());

            Console.ReadLine();
        }
    }
}
