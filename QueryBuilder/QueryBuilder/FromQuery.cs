using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryBuilder
{
    public class FromQuery<TEntity> : ISqlQuery<TEntity>
        where TEntity : EntityBase
    {

        private readonly string _select = "select";
        private readonly string _from = "from";
        private readonly string _tableName;
        private readonly string _properites;

        public FromQuery()
        {
            _tableName = typeof(TEntity).Name;
            _properites = GetProperitesAsString();
        }

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


        public string AsQuery(string properyName)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(_select + " " + properyName);
            query.Append(_from + " " + _tableName);
            return query.ToString();
        }

        public string AsQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(_select + " " + _properites);
            query.Append(_from + " " + _tableName);
            return query.ToString();
        }

    }
}
