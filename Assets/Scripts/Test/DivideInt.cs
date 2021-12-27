namespace Models
{
    public class DivideInt : IIntOperation
    {
        public int Operate(int first, int second)
        {
            return first / second;
        }
    }
}