using Assets.Source.Scripts.GameSource;
using Assets.Source.Scripts.GameSource.GameStateMachine;
using Assets.Source.Scripts.Views;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class CompositeRoot : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private StartGameView _startGameView;
        [SerializeField] private LetterListView _letterListView;
        [SerializeField] private HangmanView _hangmanView;
        [SerializeField] private GameKeyboardView _keyboardView;
        [SerializeField] private GameView _gameView;
        [SerializeField] private RestartView _restartView;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private TextSetter _textSetter;    

        [Header("Prefabs")]
        [SerializeField] private LetterItemView _letterItemPrefab;
        [SerializeField] private KeyboardItemView _keyboardItemPrefab;

        [Header("Configs")]
        [SerializeField] private GameWords _gameWords;
        [SerializeField] private int _maxMistakes;

        private void Awake()
        {
            _startGameView.gameObject.SetActive(false);
            _gameView.gameObject.SetActive(false);

            LetterFactory letterFactory = new LetterFactory(_letterItemPrefab, _keyboardItemPrefab);
            WordSelector wordSelector = new WordSelector(_gameWords);

            Keyboard keyboard = CreateKeyBoard(letterFactory);

            GameFinisher gameFinisher = new GameFinisher(new ScoreCounter(_scoreView), _maxMistakes);

            PlayerTurn playerTurn = new PlayerTurn(keyboard, _letterListView, _hangmanView, gameFinisher);

            GameStateMachine gameStateMachine = CreateStateMachine(letterFactory, wordSelector, gameFinisher, playerTurn);

            gameStateMachine.Enter<StartGameState>();
        }

        private Keyboard CreateKeyBoard(LetterFactory letterFactory)
        {
            Keyboard keyboard = new Keyboard(letterFactory, _keyboardView);
            keyboard.CreateKeyboard(_gameWords.StartLetter, _gameWords.EndLetter);
            keyboard.Disable();
            return keyboard;
        }

        private GameStateMachine CreateStateMachine(LetterFactory letterFactory, WordSelector wordSelector, GameFinisher gameFinisher, PlayerTurn playerTurn)
        {
            GameStateMachine gameStateMachine = new GameStateMachine();
            GamePrepareState gamePrepareState = new GamePrepareState(letterFactory, _letterListView, wordSelector, gameFinisher, playerTurn, gameStateMachine);
            StartGameState startState = new StartGameState(_startGameView, gameStateMachine);
            GameLoopState gameLoopState = new GameLoopState(playerTurn, _gameView, gameStateMachine, gameFinisher, wordSelector);
            RestartState restartState = new RestartState(_restartView, gameStateMachine, gameFinisher, _textSetter);

            gameStateMachine.AddState(startState);
            gameStateMachine.AddState(gamePrepareState);
            gameStateMachine.AddState(gameLoopState);
            gameStateMachine.AddState(restartState);
            return gameStateMachine;
        }
    }
}
