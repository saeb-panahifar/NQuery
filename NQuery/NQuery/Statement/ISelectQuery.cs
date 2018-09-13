namespace NQuery
{
    public interface ISelectQuery<T>
    {
        Statement Top(int number);
        Statement Top(int number, bool percent);
        ISelectQuery<T> Distinct();
    }
}
