namespace Assets.Source.Scripts.GameSource
{
    public class ScoreCounter
    {
        private readonly ScoreView _scoreView;

        private int _winCount;
        private int _loseCount;

        public ScoreCounter(ScoreView scoreView)
        {
            _scoreView = scoreView;
        }

        public void ChangeScore(bool isWin)
        {
            if (isWin)
                _winCount++;
            else
                _loseCount++;

            SetScoreOnView();
        }

        private void SetScoreOnView() =>
            _scoreView.SetScore(_winCount, _loseCount);
    }
}
