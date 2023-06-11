using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Views
{
    public class HangmanView : MonoBehaviour
    {
        private List<Image> _hangmanElements = new List<Image>();
        private int _currentIndex = 0;

        private void Awake()
        {
            GetComponentsInChildren(_hangmanElements);
            _hangmanElements = _hangmanElements.OrderBy(child => child.transform.GetSiblingIndex()).ToList();
            ClearPicture();
        }

        public void DrawHangman()
        {
            if(_currentIndex < _hangmanElements.Count)
            {
                _hangmanElements[_currentIndex].gameObject.SetActive(true);
                _currentIndex++;
            }
        }

        public void ClearPicture()
        {
            _currentIndex = 0;
            _hangmanElements.ForEach(element => element.gameObject.SetActive(false));
        }
    }
}
