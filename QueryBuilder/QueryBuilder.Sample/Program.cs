using QueryBuilder.Sample.Entities;
using System;

namespace QueryBuilder.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryResult = Query.From<Customer>()
                .Where(a => a.Id < 1 && a.Name == "ali");

            Console.WriteLine(queryResult);


            Console.ReadLine();
        }
    }
}
