using QueryBuilder.Sample.Entities;
using System;

namespace QueryBuilder.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryResult = Query.From<Customer>();

            Console.WriteLine(queryResult);


            Console.ReadLine();
        }
    }
}
