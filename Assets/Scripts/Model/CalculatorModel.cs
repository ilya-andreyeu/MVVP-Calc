using System;
using Saver;

namespace Models
{
    public class CalculatorModel : CalculatorModelBase
    {
        private const string operationKey = "operation";
        private const string stateKey = "state";
        private IIntOperation operation;
        private CalculatorControllerState state;

        public CalculatorModel(Action<int> onValueChanged) : base(onValueChanged)
        {
            LoadData();
            state = new LastNoneState(new CalculatorControllerStateActions
            {
                AccumulateMemoryCallback = AccumulateMemory,
                CalculateResultCallback = CalculateResult,
                SetMemoryValueCallback = SetMemoryValue,
                SetAccumulatedValueCallback = SetAccumulatedValue,
                AddCharToAccumulatorCallback = AddCharToAccumulator,
                OperateCallback = Operate,
                UpdateStateCallback = UpdateState,
                ClearOperationCallback = ClearOperation,
            });
            SetMemoryValueWithNotification(Memory);
        }

        private void LoadData()
        {
            settings = SaveManager.LoadData<CalculatorBaseSettings>(nameof(CalculatorModel));
        }

        private void SaveData()
        {
            SaveManager.SaveData(settings, nameof(CalculatorModel));
        }

        private void UpdateState(CalculatorControllerState newState)
        {
            state = newState;
        }

        private bool IsOperationReady => operation != null;
        
        public override void Result()
        {
            state.Result();
        }

        private void AccumulateMemory()
        {
            SetAccumulatedValue(Memory);
        }

        public override void SetValue(int value)
        {
            state.SetValue(value);
        }

        private void AddCharToAccumulator(int value)
        {
            var newValue = Accumulator * 10 + value;
            SetAccumulatedValueWithNotification(newValue);
        }

        public override void Sum()
        {
            state.Operate();
            operation = new SumInt();
        }

        private void Operate()
        {
            var newMemory = (IsOperationReady) ? GetOperation() : Accumulator;
            SetMemoryValueWithNotification(newMemory);
            SaveData();
        }

        private int GetOperation()
        {
            return operation.Operate(Memory, Accumulator);
        }

        public override void Substract()
        {
            state.Operate();
            operation = new SubstractInt();
        }

        public override void Multiply()
        {
            state.Operate();
            operation = new MultiplyInt();
        }

        public override void Divide()
        {
            state.Operate();
            operation = new DivideInt();
        }

        public override void Clear()
        {
            ClearOperation();
            ClearState();
            SetAccumulatedValueWithNotification(0);
            SetMemoryValue(0);
            SaveData();
        }

        private void ClearState()
        {
            state.SetNoneState();
        }

        private void CalculateResult()
        {
            if (IsOperationReady)
            {
                var newMemory = GetOperation();
                SetMemoryValueWithNotification(newMemory);
                SaveData();
            }
        }

        private void ClearOperation()
        {
            operation = null;
        }
    }
}