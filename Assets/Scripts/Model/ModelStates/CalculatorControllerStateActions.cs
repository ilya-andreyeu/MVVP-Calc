using System;

namespace Models
{
    public class CalculatorControllerStateActions
    {
        public Action AccumulateMemoryCallback;
        public Action CalculateResultCallback;
        public Action<int> SetMemoryValueCallback;
        public Action<int> SetAccumulatedValueCallback;
        public Action<int> AddCharToAccumulatorCallback;
        public Action OperateCallback;
        public Action<CalculatorControllerState> UpdateStateCallback;
        public Action ClearOperationCallback;
    }
}