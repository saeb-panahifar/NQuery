using QueryBuilder;
using System;


namespace QueryBuilder.Sample
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var queryResult = Query
                .From<Customer>()
                .Select(a => new { a.Id, a.LastName });

            Console.WriteLine(queryResult.ToString());

            Console.ReadLine();
        }
    }
}
