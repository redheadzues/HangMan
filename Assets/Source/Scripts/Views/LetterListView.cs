using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Views
{
    public class LetterListView : MonoBehaviour
    {
        private List<LetterItemView> _letters = new List<LetterItemView>();

        public void AddLetterItem(LetterItemView letter)
        {
            letter.transform.SetParent(transform);
            _letters.Add(letter);
        }

        public void Clear()
        {
            _letters.ForEach(letter => Destroy(letter.gameObject));
            _letters.Clear();
        }

        public void SetLetter(char letter, int index)
        {
            _letters[index].SetLetter(letter);
        }
    }
}
