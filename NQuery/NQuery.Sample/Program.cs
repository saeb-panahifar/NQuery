using System;
using System.Linq;
using System.Linq.Expressions;

namespace NQuery.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryResult = Query
                .From<Customer>()
                .Where(a => (a.FirstName == "s" && a.Id > 10) && a.LastName == "s")
                .Select(a => new { a.Id });

            Console.WriteLine(queryResult.ToString());

            Console.ReadLine();
        }
    }
}
