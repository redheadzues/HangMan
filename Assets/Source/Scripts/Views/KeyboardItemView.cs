using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Views
{
    public class KeyboardItemView : MonoBehaviour
    {
        [SerializeField] private Button _keyboardButton;
        [SerializeField] private Text _keyboardChar;

        private char _char;
        public char Char
        {
            get { return _char; }
            set 
            { 
                if(_char == '\0')
                {
                    _char = value;
                    _keyboardChar.text = _char.ToString();
                }
            }
        }

        public event Action<char> KeyDown;

        private void OnEnable() => 
            _keyboardButton.onClick.AddListener(OnKeyboardItemClick);

        private void OnDisable() => 
            _keyboardButton.onClick.RemoveListener(OnKeyboardItemClick);

        private void OnKeyboardItemClick() => 
            KeyDown?.Invoke(_char);
    }
}
