namespace Assets.Source.Scripts.GameSource.GameStateMachine
{
    public class GameLoopState : IState
    {
        private readonly WordSelector _wordSelector;
        private readonly PlayerTurn _playerTurn;
        private readonly GameView _gameView;
        private readonly GameFinisher _gameFinisher;
        private readonly GameStateMachine _gameStateMachine;

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
