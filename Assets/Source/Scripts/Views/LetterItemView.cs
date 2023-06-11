using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Views
{
    public class LetterItemView : MonoBehaviour
    {
        [SerializeField] private Text _letter;

        public void SetLetter(char letter) => 
            _letter.text = letter.ToString();
    }
}
