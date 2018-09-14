namespace NQuery
{
    public static class Func
    {
        public static string Sum(string name)
        {
            return "sum(" + name + ")";
        }
        public static string Count(string name)
        {
            return "count(" + name + ")";
        }
        public static string Avg(string name)
        {
            return "Avg(" + name + ")";
        }
    }
}
