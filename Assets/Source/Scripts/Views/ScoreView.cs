using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public string Win;
    public string Lose;

    public void SetScore(int winCount, int loseCount) => 
        _scoreText.text = $"{Win}: {winCount}. {Lose}: {loseCount}.";
}
