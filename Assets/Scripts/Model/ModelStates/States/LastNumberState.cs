namespace Models
{
    public class LastNumberState : CalculatorControllerState
    {
        public LastNumberState(CalculatorControllerStateActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            actions?.CalculateResultCallback?.Invoke();
            base.Result();
        }

        public override void SetValue(int value)
        {
            actions?.AddCharToAccumulatorCallback?.Invoke(value);
        }

        public override void Operate()
        {
            actions?.OperateCallback?.Invoke();
            base.Operate();
        }
    }
}