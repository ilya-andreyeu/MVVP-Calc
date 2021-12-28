using System;

namespace Models
{
    [Serializable]
    public struct CalculatorBaseSettings
    {
        public int accumulatedValue;
        public int memoryValue;
    }

    public abstract class CalculatorModelBase
    {
        public CalculatorModelBase(Action<int> onValueChanged)
        {
            OnCalculatedValueChanged = onValueChanged;
        }

        protected CalculatorBaseSettings settings;
        private event Action<int> OnCalculatedValueChanged;
        
        public int Accumulator => settings.accumulatedValue;
        public int Memory => settings.memoryValue;

        public abstract void Sum();
        public abstract void Substract();
        public abstract void Multiply();
        public abstract void Divide();
        public abstract void Clear();
        public abstract void Result();
        public abstract void SetValue(int value);

        protected void SetAccumulatedValue(int value)
        {
            settings.accumulatedValue = value;
        }
        protected void SetAccumulatedValueWithNotification(int value)
        {
            settings.accumulatedValue = value;
            OnCalculatedValueChanged?.Invoke(settings.accumulatedValue);
        }
        protected void SetMemoryValueWithNotification(int value)
        {
            settings.memoryValue = value;
            OnCalculatedValueChanged?.Invoke(settings.memoryValue);
        }
        protected void SetMemoryValue(int value)
        {
            settings.memoryValue = value;
        }
    }
}