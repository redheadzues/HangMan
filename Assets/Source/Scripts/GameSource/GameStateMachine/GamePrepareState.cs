using Assets.Source.Scripts.Views;

namespace Assets.Source.Scripts.GameSource.GameStateMachine
{
    public class GamePrepareState : IState
    {
        private LetterFactory _letterFactory;
        private LetterListView _letterListView;
        private WordSelector _wordSelector;
        private GameFinisher _gameFinisher;
        private PlayerTurn _playerTurn;
        private GameStateMachine _gameStateMachine;

        private string _word;

        public GamePrepareState(
            LetterFactory letterFactory,
            LetterListView letterListView,
            WordSelector wordSelector,
            GameFinisher gameFinisher,
            PlayerTurn playerTurn,
            GameStateMachine gameStateMachine)
        {
            _letterFactory = letterFactory;
            _letterListView = letterListView;
            _wordSelector = wordSelector;
            _gameFinisher = gameFinisher;
            _playerTurn = playerTurn;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _letterListView.Clear();
            _word = _wordSelector.GetWord();
            FillWordView(_word);
            _gameStateMachine.Enter<GameLoopState>();
        }


        public void Exit() => 
            StartNewRound(_word);

        private void StartNewRound(string word)
        {
            _playerTurn.Eneble();
            _playerTurn.StartNewRound(word);
            _gameFinisher.StartNewRound(word);

        }

        private void FillWordView(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var letter = _letterFactory.CreateLetter(_letterListView.transform);
                _letterListView.AddLetterItem(letter);
            }
        }
    }
}
