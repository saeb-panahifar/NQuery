using System.Collections.Generic;
using System.Linq;

namespace QueryBuilder
{
    public class FromQuery<TEntity>
        where TEntity : EntityBase
    {
        private readonly string select = "select";
        private readonly string from = "from";

        private string GetProperitesAsString()
        {
            var properties = typeof(TEntity).GetProperties();
            List<string> properyName = new List<string>();

            foreach (var item in properties)
            {
                properyName.Add(item.Name);
            }

            return properyName.Aggregate((s1, s2) => s1 + ", " + s2);
        }

        public string AsQuery()
        {
            var query = select + " " + GetProperitesAsString() + " \n" + 
                        from + " " + typeof(TEntity).Name;

            return query;
        }
    }
}
