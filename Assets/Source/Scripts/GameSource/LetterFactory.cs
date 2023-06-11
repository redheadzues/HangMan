using Assets.Source.Scripts.Views;
using UnityEngine;

namespace Assets.Source.Scripts.GameSource
{
    public class LetterFactory
    {
        private readonly LetterItemView _letterPrefab;
        private readonly KeyboardItemView _keyboardPrefab;

        public LetterFactory(LetterItemView prefab, KeyboardItemView keyboardPrefab)
        {
            _letterPrefab = prefab;
            _keyboardPrefab = keyboardPrefab;
        }

        public LetterItemView CreateLetter(Transform parrent) =>
            Object.Instantiate(_letterPrefab, parrent);

        public KeyboardItemView CreateKeyboardItem(Transform parrent) =>
            Object.Instantiate(_keyboardPrefab, parrent);
    }
}
