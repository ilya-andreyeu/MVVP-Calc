using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private InputField inputView;
        [SerializeField] private Button plusButton;
        [SerializeField] private Button minusButton;
        [SerializeField] private Button multiplyButton;
        [SerializeField] private Button divideButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private Button resultButton;
        [SerializeField] private Keyboard keyboard;

        private event Action<string> onInputUpdated;
        private event Action onPlusButtonClicked;
        private event Action onMinusButtonClicked;
        private event Action onMultiplyButtonClicked;
        private event Action onDivideButtonClicked;
        private event Action onClearButtonClicked;
        private event Action onResultButtonClicked;

        private CalculatorViewModel calculatorViewModel;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeKeyboard();
            SubscribeInputs();
            SubscribeModelView();
        }

        private void InitializeKeyboard()
        {
            keyboard.Initialize(OnKeyboardPressedHandler);
        }

        private void OnKeyboardPressedHandler(string value)
        {
            OnInputViewValueChangedHandler(value);
        }

        private void SubscribeInputs()
        {
            inputView.onEndEdit.AddListener(OnInputViewValueChangedHandler);
            plusButton.onClick.AddListener(OnPlusButtonClickHandler);
            minusButton.onClick.AddListener(OnMinusButtonClickHandler);
            multiplyButton.onClick.AddListener(OnMultiplyButtonClickHandler);
            divideButton.onClick.AddListener(OnDivideButtonClickHandler);
            clearButton.onClick.AddListener(OnClearButtonClickHandler);
            resultButton.onClick.AddListener(OnResultButtonClickHandler);
        }

        private void OnResultButtonClickHandler()
        {
            onResultButtonClicked?.Invoke();
        }

        private void SubscribeModelView()
        {
            calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.Initialize(this, OnInputViewValueSetHandler);
        }

        private void OnInputViewValueSetHandler(string value)
        {
            inputView.SetTextWithoutNotify(value);
        }

        private void OnInputViewValueChangedHandler(string value)
        {
            onInputUpdated?.Invoke(value);
        }

        private void OnPlusButtonClickHandler()
        {
            onPlusButtonClicked?.Invoke();
        }

        private void OnMinusButtonClickHandler()
        {
            onMinusButtonClicked?.Invoke();
        }

        private void OnMultiplyButtonClickHandler()
        {
            onMultiplyButtonClicked?.Invoke();
        }

        private void OnDivideButtonClickHandler()
        {
            onDivideButtonClicked?.Invoke();
        }

        private void OnClearButtonClickHandler()
        {
            onClearButtonClicked?.Invoke();
        }

        public void SetCallbacks(ICallbacks callbacks)
        {
            if (callbacks is CalculatorActions actions)
            {
                onInputUpdated = actions.onInputUpdated;
                onPlusButtonClicked = actions.onPlusButtonClicked;
                onMinusButtonClicked = actions.onMinusButtonClicked;
                onMultiplyButtonClicked = actions.onMultiplyButtonClicked;
                onDivideButtonClicked = actions.onDivideButtonClicked;
                onClearButtonClicked = actions.onClearButtonClicked;
                onResultButtonClicked = actions.onResultButtonClicked;
            }
        }
    }
}