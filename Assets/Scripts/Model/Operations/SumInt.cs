namespace Models
{
    public class SumInt : IIntOperation
    {
        public int Operate(int first, int second)
        {
            return first + second;
        }
    }
}