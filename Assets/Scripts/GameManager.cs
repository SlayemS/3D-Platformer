using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int currentScore = 0;
    public int totalScore = 0;
    public Text scoreText;
    public bool powerUp = false;

    public void AddScore(int scoreToAdd) {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Instance.scoreText = FindObjectOfType<Text>();

        DontDestroyOnLoad(Instance);
    }

    public void LevelComplete()
    {
        totalScore = currentScore;
    }

    public void ResetLevelScore()
    {
        currentScore = totalScore;
    }

    public void ResetGameScore()
    {
        currentScore = 0;
        totalScore = 0;
    }

    public void JumpPowerUpOn()
    {
        powerUp = true;
    }

    public void JumpPowerUpOff()
    {
        powerUp = false;
    }
}
