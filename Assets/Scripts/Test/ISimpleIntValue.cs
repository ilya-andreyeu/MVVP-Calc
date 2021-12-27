using System;

namespace Models
{
    public interface ISimpleIntValue
    {
        void SetValue(int value);
        void SetCallback(Action<int> onValueChanged);
    }
}