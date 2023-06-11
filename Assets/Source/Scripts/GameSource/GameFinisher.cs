using System;

namespace Assets.Source.Scripts.GameSource
{
    public class GameFinisher
    {
        private readonly ScoreCounter _scoreCounter;
        private readonly int _maxMistakes;

        private int _mistakesCount;
        private int _guessedCount;
        private string _guessWord;

        public bool WinStatus { get; private set; }
        public event Action Happend;

        public GameFinisher(ScoreCounter scoreCounter, int maxMistakes)
        {
            _scoreCounter = scoreCounter;
            _maxMistakes = maxMistakes;
        }

        public void StartNewRound(string guessWord)
        {
            _guessedCount = 0;
            _mistakesCount = 0;
            _guessWord = guessWord;
        }

        public void HandlePlayerAction(int guessCount)
        {
            _guessedCount += guessCount;

            if (guessCount == 0)
                _mistakesCount++;

            if (_mistakesCount > _maxMistakes || _guessedCount >= _guessWord.Length)
                FinishGame();
        }

        private void FinishGame()
        {
            bool isWin = _mistakesCount < _maxMistakes;
            _scoreCounter.ChangeScore(isWin);
            WinStatus = isWin;
            Happend?.Invoke();
        }
    }
}
