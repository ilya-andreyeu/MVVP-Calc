using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class KeyButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private int number;

        private Action<string> onButtonClicked;

        private void SetTextView()
        {
            var text = button.GetComponentInChildren<Text>();
            if (text != null)
            {
                text.text = number.ToString();
            }
        }

        public void Initialize(Action<string> setValueCallback)
        {
            SetTextView();
            onButtonClicked = setValueCallback;
            button.onClick.AddListener(OnButtonClickedHandler);
        }

        private void OnButtonClickedHandler()
        {
            onButtonClicked?.Invoke(number.ToString());
        }
    }
}