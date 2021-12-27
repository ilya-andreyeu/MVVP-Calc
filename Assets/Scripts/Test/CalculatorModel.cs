using System;
using UnityEngine;

namespace Models
{
    public enum InputType
    {
        None,
        Result,
        Operation,
        Number,
    }

    public abstract class CalculatorControllerState
    {
        protected CalculatorModelActions actions;
        public CalculatorControllerState(CalculatorModelActions actions)
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
    }

    public class CalculatorModelActions
    {
        public Action AccumulateMemoryCallback;
        public Action CalculateResultCallback;
        public Action<int> SetMemoryValueCallback;
        public Action<int> SetAccumulatedValueCallback;
        public Action<int> SetCharToAccumulatorCallback;
        public Action OperateCallback;
        public Action<CalculatorControllerState> UpdateStateCallback;
    }

    

    public class LastResultState : CalculatorControllerState
    {
        public LastResultState(CalculatorModelActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            throw new NotImplementedException();
        }

        public override void SetValue(int value)
        {
            throw new NotImplementedException();
        }

        public override void Operate()
        {
            throw new NotImplementedException();
        }
    }

    public class LastOperationState : CalculatorControllerState
    {
        public LastOperationState(CalculatorModelActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            actions.AccumulateMemoryCallback?.Invoke();
            actions.CalculateResultCallback?.Invoke();
            actions.UpdateStateCallback?.Invoke(new LastResultState(actions));

        }

        public override void SetValue(int value)
        {
            throw new System.NotImplementedException();
        }

        public override void Operate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class LastNumberState : CalculatorControllerState
    {
        public LastNumberState(CalculatorModelActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            throw new NotImplementedException();
        }

        public override void SetValue(int value)
        {
            throw new NotImplementedException();
        }

        public override void Operate()
        {
            throw new NotImplementedException();
        }
    }

    public class LastNoneState : CalculatorControllerState
    {
        public LastNoneState(CalculatorModelActions actions) : base(actions)
        {
        }

        public override void Result()
        {
            throw new NotImplementedException();
        }

        public override void SetValue(int value)
        {
            throw new NotImplementedException();
        }

        public override void Operate()
        {
            throw new NotImplementedException();
        }
    }



    public class CalculatorModel : CalculatorModelBase
    {
        private IIntOperation operation;
        private InputType inputType;

        private bool IsOperationReady => operation != null;
        
        public override void Result()
        {
            switch (inputType)
            {
                case InputType.None:
                case InputType.Result:
                    CalculateResult();
                    break;
                case InputType.Operation:
                    SetAccumulatedValue(Memory);
                    CalculateResult();
                    break;
                case InputType.Number:
                    CalculateResult();
                    break;
                default:
                    break;
            }

            inputType = InputType.Result;
        }

        public override void SetValue(int value)
        {
            switch (inputType)
            {
                case InputType.None:
                case InputType.Result:
                    SetMemoryValue(0);
                    SetAccumulatedValue(0);
                    AddCharToAccumulator(value);
                    break;
                case InputType.Operation:
                    SetAccumulatedValue(0);
                    AddCharToAccumulator(value);
                    break;
                case InputType.Number:
                    AddCharToAccumulator(value);
                    break;
                default:
                    break;
            }
            
            inputType = InputType.Number;
        }

        private void AddCharToMemory(int value)
        {
            var newValue = Memory * 10 + value;
            SetMemoryValueWithNotification(newValue);
        }

        private void AddCharToAccumulator(int value)
        {
            var newValue = Accumulator * 10 + value;
            SetAccumulatedValueWithNotification(newValue);
        }

        public override void Sum()
        {
            Operate();
            operation = new SumInt();
        }

        private void Operate()
        {
            var newMemory = (IsOperationReady) ? GetOperation() : Accumulator;
            SetMemoryValueWithNotification(newMemory);

            switch (inputType)
            {
                case InputType.None:
                case InputType.Result:
                    break;
                case InputType.Operation:
                    break;
                case InputType.Number:
                    //var newMemory = (IsOperationReady) ? GetOperation() : Accumulator; 
                    SetMemoryValueWithNotification(newMemory);
                    break;
                default:
                    break;

            }

            inputType = InputType.Operation;
        }

        private int GetOperation()
        {
            return operation.Operate(Memory, Accumulator);
        }

        public override void Substract()
        {
            Operate();
            operation = new SubstractInt();
        }

        public override void Multiply()
        {
            Operate();
            operation = new MultiplyInt();
        }

        public override void Divide()
        {
            Operate();
            operation = new DivideInt();
        }

        public override void Clear()
        {
            ClearOperation();
            SetAccumulatedValueWithNotification(0);
            SetMemoryValue(0);
        }

        private void CalculateResult()
        {
            if (IsOperationReady)
            {
                var newMemory = GetOperation();
                SetMemoryValueWithNotification(newMemory);
            }
        }

        private void ClearOperation()
        {
            operation = null;
        }
    }
}