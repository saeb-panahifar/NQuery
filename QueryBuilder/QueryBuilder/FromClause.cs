using System.Text;

namespace QueryBuilder
{
    public class FromClause<T> : Clause
    {
        public override string Name => "from";
        public FromClause()
        {

        }
        public string TableAsString()
        {
            return typeof(T).Name;
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();
            query.Append(this.Name + " ");
            query.AppendLine(this.TableAsString());

            return query.ToString();
        }
    }
}
