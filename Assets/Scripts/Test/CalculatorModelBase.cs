using System;

namespace Models
{
    public abstract class CalculatorModelBase : ISimpleCalculator, ISimpleIntValue
    {
        private event Action<int> OnCalculatedValueChanged;
        //private int calculatedValue;
        //public int Value => calculatedValue;
        public abstract void Sum();
        public abstract void Substract();
        public abstract void Multiply();
        public abstract void Divide();
        public abstract void Clear();
        public abstract void Result();
        public abstract void SetValue(int value);
        public void SetCallback(Action<int> onValueChanged)
        {
            OnCalculatedValueChanged = onValueChanged;
        }
        //protected void SetCalculatedValue(int value)
        //{
        //    calculatedValue = value;
        //}
        //protected void SetCalculatedValueWithNotification(int value)
        //{
        //    calculatedValue = value;
        //    OnCalculatedValueChanged?.Invoke(calculatedValue);
        //}

        public int Accumulator => accumulatedValue;
        private int accumulatedValue;
        public int Memory => memoryValue;
        private int memoryValue;

        protected void SetAccumulatedValue(int value)
        {
            accumulatedValue = value;
        }
        protected void SetAccumulatedValueWithNotification(int value)
        {
            accumulatedValue = value;
            OnCalculatedValueChanged?.Invoke(accumulatedValue);
        }
        protected void SetMemoryValueWithNotification(int value)
        {
            memoryValue = value;
            OnCalculatedValueChanged?.Invoke(memoryValue);
        }

        protected void SetMemoryValue(int value)
        {
            memoryValue = value;
        }
    }
}