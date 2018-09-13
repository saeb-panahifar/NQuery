using NQuery.DataAnnotations;

namespace NQuery.Sample
{
    [TableMap("customer")]
    public class Customer
    {
        [ColumnMap("id")]
        public int Id { get; set; }
        [ColumnMap("firstName")]
        public string FirstName { get; set; }
        [ColumnMap("lastName")]
        public string LastName { get; set; }
        [ColumnMap("age")]
        public int Age { get; set; }
    }
}
