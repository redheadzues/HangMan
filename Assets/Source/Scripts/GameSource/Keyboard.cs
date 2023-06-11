using Assets.Source.Scripts.Views;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.GameSource
{
    public class Keyboard
    {
        private LetterFactory _letterFactory;
        private GameKeyboardView _keyboardView;

        private HashSet<int> _enteredCharIndexes;

        public Action<char> KeyDown;

        public Keyboard(LetterFactory letterFactory, GameKeyboardView keyboardView)
        {
            _letterFactory = letterFactory;
            _keyboardView = keyboardView;
        }

        public void CreateKeyboard(char startLetter, char ednLetter)
        {
            for (int i = startLetter; i <= ednLetter; i++)
            {
                KeyboardItemView keyboardItem = _letterFactory.CreateKeyboardItem(_keyboardView.transform);

                keyboardItem.Char = (char)i;
                _keyboardView.AddKeyboardItem(keyboardItem);
            }

            _enteredCharIndexes = new HashSet<int>();
        }

        public void Eneble()
        {
            _keyboardView.KeyDown += OnKeyDown;
            _keyboardView.gameObject.SetActive(true);
        }

        public void Disable()
        {
            _keyboardView.KeyDown -= OnKeyDown;
            _keyboardView.gameObject.SetActive(false);
            _enteredCharIndexes.Clear();
        }


        private void OnKeyDown(char letter)
        {
            if (_enteredCharIndexes.Contains(letter))
                return;

            _enteredCharIndexes.Add(letter);
            KeyDown?.Invoke(letter);
        }

    }
}
