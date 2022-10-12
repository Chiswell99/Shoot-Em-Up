using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreValueText;

    private void Start()
    {
        UpdateScoreValueText(GameController.Instance.PlayerScore);
        GameController.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int updateScore)
    {
        UpdateScoreValueText(updateScore);
    }
    public void UpdateScoreValueText(int newScore)
    {
        scoreValueText.text = newScore.ToString();
    }

    private void OnDestroy()
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.OnScoreChanged -= OnScoreChanged;
        }
    }
}
