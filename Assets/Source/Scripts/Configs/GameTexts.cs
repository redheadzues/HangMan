using UnityEngine;

namespace Assets.Source.Scripts
{
    [CreateAssetMenu(fileName = "GameTexts", menuName = "Game Config/Game Texts")]
    public class GameTexts : ScriptableObject
    {
        [field: SerializeField] public string Rules;
        [field: SerializeField] public string WinText;
        [field: SerializeField] public string LoseText;
        [field: SerializeField] public string StartButtonText;
        [field: SerializeField] public string RestartButtonText;
        [field: SerializeField] public string Win;
        [field: SerializeField] public string Lose;
        [field: SerializeField] public string Header;
    }
}
