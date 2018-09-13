using System;


namespace NQuery.Sample
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
                .Select(a => new { a.FirstName })
                .Where(a => a.Id == 1 && a.LastName == "Paul")
                .GroupBy(a => new { a.FirstName })
                .OrderBy(a => new { a.Id })
                .Distinct()
                .Top(10);

            Console.WriteLine(queryResult.ToString());

            Console.ReadLine();
        }
    }
}
