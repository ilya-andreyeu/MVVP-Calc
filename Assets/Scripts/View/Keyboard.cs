using System;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private List<KeyButton> buttons;
        private Action<string> onButtonClick;

        public void Initialize(Action<string> onKeyboardPressed)
        {
            this.onButtonClick = onKeyboardPressed;

            foreach (var keyButton in buttons)
            {
                keyButton.Initialize(OnKeyButtonPressedHandler);
            }
        }

        private void OnKeyButtonPressedHandler(string value)
        {
            onButtonClick?.Invoke(value);
        }
    }
}