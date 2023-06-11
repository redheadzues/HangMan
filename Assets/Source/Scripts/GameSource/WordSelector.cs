using System.Collections.Generic;

namespace Assets.Source.Scripts.GameSource
{
    public class WordSelector
    {
        private List<string> _words;
        private int _guessedCount;
        private int _currentWordIndex;

        private System.Random _random = new System.Random();

        public WordSelector(GameWords gameWords)
        {
            _words = new List<string>(gameWords.Words.Count);

            ParseWords(gameWords);
        }

        public string GetWord()
        {
            SetNewWordIndex();

            return _words[_currentWordIndex];
        }

        public void WordGuessed()
        {
            string tempWord = _words[_words.Count - 1 - _guessedCount];
            _words[_words.Count - 1 - _guessedCount] = _words[_currentWordIndex];
            _words[_currentWordIndex] = tempWord;
            _guessedCount++;
        }

        private void ParseWords(GameWords gameWords)
        {
            foreach (string word in gameWords.Words)
            {
                _words.Add(word.ToUpper());
            }
        }

        private void SetNewWordIndex()
        {
            if (_guessedCount >= _words.Count)
                _guessedCount = 0;

            int randomIndex = _random.Next(0, _words.Count - 1 - _guessedCount);
            _currentWordIndex = randomIndex;
        }
    }
}
