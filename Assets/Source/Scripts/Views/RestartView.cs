using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartView : MonoBehaviour
{
    [SerializeField] private Text _resultText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _restartButtonText;

    public event Action RestartButtonClicked;

    private void OnEnable() => 
        _restartButton.onClick.AddListener(OnRestartButtonClicked);

    private void OnDisable() => 
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);

    public void SetResultText(string resultText) => 
        _resultText.text = resultText;

    public void SetButtonText(string text) =>
        _restartButtonText.text = text;

    private void OnRestartButtonClicked() => 
        RestartButtonClicked?.Invoke();

}
