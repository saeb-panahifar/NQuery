using System.Text;

namespace NQuery
{
    public class FromClause<T> : Clause
    {
        public override string Name => "from";

        public FromClause()
        {

        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();

            query.Append(this.Name + " ");

            query.AppendLine(this.TableAsString());

            return query.ToString();
        }

        private string TableAsString()
        {
            return typeof(T).Name;
        }
    }
}
