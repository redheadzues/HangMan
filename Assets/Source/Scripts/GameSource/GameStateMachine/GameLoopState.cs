namespace Assets.Source.Scripts.GameSource.GameStateMachine
{
    public class GameLoopState : IState
    {
        private WordSelector _wordSelector;
        private PlayerTurn _playerTurn;
        private GameView _gameView;
        private GameFinisher _gameFinisher;
        private GameStateMachine _gameStateMachine;

        public GameLoopState(
            PlayerTurn playerTurn,
            GameView gameView,
            GameStateMachine gameStateMachine,
            GameFinisher gameFinisher,
            WordSelector wordSelector)
        {
            _playerTurn = playerTurn;
            _gameView = gameView;
            _gameFinisher = gameFinisher;
            _gameStateMachine = gameStateMachine;
            _wordSelector = wordSelector;
        }

        public void Enter()
        {
            _gameView.gameObject.SetActive(true);
            _gameFinisher.Happend += OnGameFinished;
        }

        public void Exit()
        {
            _playerTurn.Disable();
            _gameFinisher.Happend -= OnGameFinished;
        }

        private void OnGameFinished()
        {
            if (_gameFinisher.WinStatus)
                _wordSelector.WordGuessed();

            _gameStateMachine.Enter<RestartState>();
        }
    }
}
