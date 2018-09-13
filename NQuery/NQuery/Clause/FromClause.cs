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

            query.AppendLine(this.TableNameAsString());

            return query.ToString();
        }

        private string TableNameAsString()
        {
            return typeof(T).Name;
        }
    }
}
