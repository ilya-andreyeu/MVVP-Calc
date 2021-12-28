using System;
using Models;
using Views;

public class CalculatorViewModel
{
    private CalculatorModelBase calculatorModel;
    private event Action<string> onCalculationValueChanged;
    private void InitializeInternal()
    {
        calculatorModel = new CalculatorModel(OnModelValueChangedHandler);
    }

    private void OnModelValueChangedHandler(int value)
    {
        onCalculationValueChanged?.Invoke(value.ToString());
    }

    public void Initialize(ICalculatorView view, Action<string> onValueSetCallback)
    {
        onCalculationValueChanged = onValueSetCallback;
        view.SetCallbacks(new CalculatorActions
        {
            onInputUpdated = OnInputUpdatedHandler,
            onPlusButtonClicked = OnPlusButtonClickedHandler,
            onMinusButtonClicked = OnMinusButtonClickedHandler,
            onMultiplyButtonClicked = OnMultiplyButtonClickedHandler,
            onDivideButtonClicked = OnDivideButtonClickedHandler,
            onClearButtonClicked = OnClearButtonClickedHandler,
            onResultButtonClicked = OnResultButtonClickedHandler,
        });
        InitializeInternal();
    }

    private void OnResultButtonClickedHandler()
    {
        calculatorModel.Result();
    }

    private void OnInputUpdatedHandler(string value)
    {
        if (Int32.TryParse(value, out var result))
        {
            calculatorModel.SetValue(result);
        }
    }

    private void OnPlusButtonClickedHandler()
    {
        calculatorModel.Sum();
    }

    private void OnMinusButtonClickedHandler()
    {
        calculatorModel.Substract();
    }

    private void OnMultiplyButtonClickedHandler()
    {
        calculatorModel.Multiply();
    }

    private void OnDivideButtonClickedHandler()
    {
        calculatorModel.Divide();
    }

    private void OnClearButtonClickedHandler()
    {
        calculatorModel.Clear();
    }
}