using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts
{
    [CreateAssetMenu(fileName = "GameWords", menuName = "Game Config/Game Words")]
    public class GameWords : ScriptableObject
    {
        [SerializeField] private List<string> _words;
        [field: SerializeField] public char StartLetter;
        [field: SerializeField] public char EndLetter;

        public IReadOnlyList<string> Words => _words;
    }
}

