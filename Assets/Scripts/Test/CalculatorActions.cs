using System;

public class CalculatorActions : ICallbacks
{
    public Action<string> onInputUpdated;
    public Action onPlusButtonClicked;
    public Action onMinusButtonClicked;
    public Action onMultiplyButtonClicked;
    public Action onDivideButtonClicked;
    public Action onClearButtonClicked;
    public Action onResultButtonClicked;
}