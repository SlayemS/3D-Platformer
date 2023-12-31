using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public void OnRestartGame() {
        GameManager.Instance.ResetGameScore();
        SceneManager.LoadScene(1);
    }

    public void OnGameStop() {
        Application.Quit();
    }
}