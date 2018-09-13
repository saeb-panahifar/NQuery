namespace NQuery
{
    public interface ISelectQuery<T> : ISelectFilterQuery<T>
    {
        Statement Top(int number);
        Statement Top(int number, bool percent);
        ISelectQuery<T> Distinct();
    }
}
