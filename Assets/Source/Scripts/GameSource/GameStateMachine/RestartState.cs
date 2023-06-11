using Assets.Source.Scripts.Views;

namespace Assets.Source.Scripts.GameSource.GameStateMachine
{
    public class RestartState : IState
    {
        private readonly RestartView _restartGameView;
        private readonly GameStateMachine _gameStateMachine;
        private readonly GameFinisher _gameFinisher;
        private readonly TextSetter _textSetter;

        public RestartState(RestartView restartGameView, GameStateMachine gameStateMachine, GameFinisher gameFinisher, TextSetter textSetter)
        {
            _restartGameView = restartGameView;
            _gameStateMachine = gameStateMachine;
            _gameFinisher = gameFinisher;
            _textSetter = textSetter;
        }

        public void Enter()
        {
            _restartGameView.gameObject.SetActive(true);
            _restartGameView.RestartButtonClicked += OnRestartButtonClicked;

            if (_gameFinisher.WinStatus)
                _textSetter.SetWinText();
            else
                _textSetter.SetLoseText();
        }

        public void Exit()
        {
            _restartGameView.RestartButtonClicked -= OnRestartButtonClicked;
            _restartGameView.gameObject.SetActive(false);
        }

        private void OnRestartButtonClicked() =>
            _gameStateMachine.Enter<GamePrepareState>();
    }
}
