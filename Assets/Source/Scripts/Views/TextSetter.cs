using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Views
{
    public class TextSetter : MonoBehaviour
    {
        [SerializeField] private GameTexts _texts;
        [SerializeField] private StartGameView _startGameView;
        [SerializeField] private RestartView _restartView;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private Text _header;

        private void Awake()
        {
            _startGameView.SetButtonText(_texts.StartButtonText);
            _startGameView.SetRulesText(_texts.Rules);
            _restartView.SetButtonText(_texts.RestartButtonText);
            _scoreView.Win = _texts.Win;
            _scoreView.Lose = _texts.Lose;
            _header.text = _texts.Header;
            
        }

        public void SetWinText() => 
            _restartView.SetResultText(_texts.WinText);

        public void SetLoseText() => 
            _restartView.SetResultText(_texts.LoseText);
    }
}
