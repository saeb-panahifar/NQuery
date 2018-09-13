namespace NQuery
{
    public interface ISelectStatement
    {
        Statement Top(int number);
        Statement Top(int number, bool percent);
    }
}
