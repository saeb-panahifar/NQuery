namespace NQuery
{
    public static class Query
    {
        public static SelectStatement<T> From<T>()
        { 
            return new SelectStatement<T>();
        }
    }
}
