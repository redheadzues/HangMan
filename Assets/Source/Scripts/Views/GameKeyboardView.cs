using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Views
{
    public class GameKeyboardView : MonoBehaviour
    {
        private List<KeyboardItemView> _items = new List<KeyboardItemView>();
        public event Action<char> KeyDown;

        private void OnDestroy() => 
            _items.ForEach(item => item.KeyDown -= OnKeyDown);

        public void AddKeyboardItem(KeyboardItemView keyboarItem)
        {
            _items.Add(keyboarItem);
            keyboarItem.KeyDown += OnKeyDown;
        }

        public void Clear()
        {
            _items.ForEach(item => item.KeyDown -= KeyDown);
            _items.ForEach(item => Destroy(item.gameObject));
            _items.Clear();
        }

        private void OnKeyDown(char letter) =>
            KeyDown?.Invoke(letter);
    }
}
