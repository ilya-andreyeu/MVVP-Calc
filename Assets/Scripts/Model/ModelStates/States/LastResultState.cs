namespace Models
{
    public class LastResultState : CalculatorControllerState
    {
        public LastResultState(CalculatorControllerStateActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            actions?.CalculateResultCallback?.Invoke();
        }

        public override void SetValue(int value)
        {
            actions?.SetMemoryValueCallback?.Invoke(0);
            actions?.SetAccumulatedValueCallback?.Invoke(0);
            actions?.ClearOperationCallback?.Invoke();
            actions?.AddCharToAccumulatorCallback?.Invoke(value);
            base.SetValue(value);
        }
    }
}