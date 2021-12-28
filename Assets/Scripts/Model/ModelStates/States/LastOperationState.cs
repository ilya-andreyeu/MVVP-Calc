namespace Models
{
    public class LastOperationState : CalculatorControllerState
    {
        public LastOperationState(CalculatorControllerStateActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            actions?.AccumulateMemoryCallback?.Invoke();
            actions?.CalculateResultCallback?.Invoke();
            base.Result();
        }

        public override void SetValue(int value)
        {
            actions?.SetAccumulatedValueCallback?.Invoke(0);
            actions?.AddCharToAccumulatorCallback?.Invoke(value);
            base.SetValue(value);
        }

        public override void Operate()
        {
        }
    }
}