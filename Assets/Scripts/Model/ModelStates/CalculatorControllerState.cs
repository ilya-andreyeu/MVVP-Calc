namespace Models
{
    public abstract class CalculatorControllerState
    {
        protected CalculatorControllerStateActions actions;
        public CalculatorControllerState(CalculatorControllerStateActions actions)
        {
            this.actions = actions;
        }

        public virtual void Result()
        {
            actions?.UpdateStateCallback?.Invoke(new LastResultState(actions));
        }

        public virtual void SetValue(int value)
        {
            actions?.UpdateStateCallback?.Invoke(new LastNumberState(actions));
        }

        public virtual void Operate()
        {
            actions?.UpdateStateCallback?.Invoke(new LastOperationState(actions));
        }

        public void SetNoneState()
        {
            actions?.UpdateStateCallback(new LastNoneState(actions));
        }
    }
}