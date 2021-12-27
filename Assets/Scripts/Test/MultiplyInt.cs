namespace Models
{
    public class MultiplyInt : IIntOperation
    {
        public int Operate(int first, int second)
        {
            return first * second;
        }
    }
}