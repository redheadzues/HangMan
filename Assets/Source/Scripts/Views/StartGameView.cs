using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Views
{
    public class StartGameView : MonoBehaviour
    {
        [SerializeField] private Text _buttonText;
        [SerializeField] private Text _rulesText;
        [SerializeField] private Button _startButton;

        public Button StartButton => _startButton;

        public void SetButtonText(string header) =>
            _buttonText.text = header;

        public void SetRulesText(string rules) =>
            _rulesText.text = rules;
    }
}
