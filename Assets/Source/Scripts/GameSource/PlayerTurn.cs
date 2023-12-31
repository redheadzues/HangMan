﻿using Assets.Source.Scripts.Views;

namespace Assets.Source.Scripts.GameSource
{
    public class PlayerTurn
    {
        private readonly Keyboard _keyboard;
        private readonly LetterListView _letterListView;
        private readonly HangmanView _hangmanView;
        private readonly GameFinisher _gameFinisher;

        private string _guessWord;

        public PlayerTurn(Keyboard keyboard, LetterListView letterList, HangmanView hangmanView, GameFinisher gameFinisher)
        {
            _keyboard = keyboard;
            _letterListView = letterList;
            _hangmanView = hangmanView;
            _gameFinisher = gameFinisher;
        }

        public void StartNewRound(string word)
        {
            _guessWord = word;
            _hangmanView.ClearPicture();
        }

        public void Eneble()
        {
            _keyboard.Eneble();
            _keyboard.KeyDown += OnKeyDown;
        }

        public void Disable()
        {
            _keyboard.KeyDown -= OnKeyDown;
            _keyboard.Disable();
        }

        private void OnKeyDown(char letter)
        {
            if (TryOpenLetter(letter, out int guessCount) == false)
                _hangmanView.DrawHangman();

            _gameFinisher.HandlePlayerAction(guessCount);
        }

        private bool TryOpenLetter(char letter, out int guessCount)
        {
            guessCount = 0;

            for (int i = 0; i < _guessWord.Length; i++)
            {
                if (_guessWord[i] == letter)
                {
                    _letterListView.SetLetter(letter, i);
                    guessCount++;
                }
            }

            return guessCount > 0;
        }
    }
}
