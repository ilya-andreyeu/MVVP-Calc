namespace Models
{
    public class LastNoneState : CalculatorControllerState
    {
        public LastNoneState(CalculatorControllerStateActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            actions?.CalculateResultCallback?.Invoke();
            base.Result();
        }

        public override void SetValue(int value)
        {
            actions?.SetMemoryValueCallback?.Invoke(0);
            actions?.SetAccumulatedValueCallback?.Invoke(0);
            actions?.AddCharToAccumulatorCallback?.Invoke(value);
            base.SetValue(value);
        }
    }
}