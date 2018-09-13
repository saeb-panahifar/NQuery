using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Sample.Entities
{
    public class Customer : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
    }
}
