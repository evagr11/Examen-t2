using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreCounter;
    public int score = 0;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
        GameEvents.EnemyDied.AddListener(EnemyDying);
    }

    public void UpdateScoreText()
    {
        scoreCounter.text = "Score: " + score;
    }

    public void EnemyDying()
    {
        score++;
        UpdateScoreText();
    }
}
