namespace NQuery
{
    public interface ISelectQuery<T> : ISelectFilterQuery<T>, ISelectGroupableQuery<T>
    {
        Statement Top(int number);
        Statement Top(int number, bool percent);
        ISelectQuery<T> Distinct();
    }
}
