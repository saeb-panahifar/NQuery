using System;

namespace NQuery.DataAnnotations
{
    public class TableMap : Attribute
    {
        public readonly string Name;

        public TableMap(string name)
        {
            Name = name;
        }
       
    }
}
