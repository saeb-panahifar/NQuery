using System;

namespace NQuery.DataAnnotations
{
    public class ColumnMap : Attribute
    {
        public readonly string Name;

        public ColumnMap(string name)
        {
            Name = name;
        }
    }
}
