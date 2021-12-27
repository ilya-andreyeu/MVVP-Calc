namespace Models
{
    public class SubstractInt : IIntOperation
    {
        public int Operate(int first, int second)
        {
            return first - second;
        }
    }
}