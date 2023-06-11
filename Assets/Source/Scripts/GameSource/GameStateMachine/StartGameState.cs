using Assets.Source.Scripts.Views;

namespace Assets.Source.Scripts.GameSource.GameStateMachine
{
    public class StartGameState : IState
    {
        private readonly StartGameView _startGameView;
        private readonly GameStateMachine _stateMachine;

        public StartGameState(StartGameView startGameView, GameStateMachine stateMachine)
        {
            _startGameView = startGameView;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _startGameView.gameObject.SetActive(true);
            _startGameView.StartButton.onClick.AddListener(OnStartButtonClicked);
        }

        public void Exit() => 
            _startGameView.gameObject.SetActive(false);

        private void OnStartButtonClicked() =>
            _stateMachine.Enter<GamePrepareState>();
    }
}
