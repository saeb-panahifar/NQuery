using System;
using System.Collections.Generic;
using System.Linq;

namespace NQuery.Sample
{
   
    class Program
    {
        static void Main(string[] args)
        {
            var queryResult = Query
                .From<Customer>()
                .Select(x => new { Id = Func.Sum(x.Id) });


            Console.WriteLine(queryResult.ToString());

            Console.ReadLine();
        }
    }
}
