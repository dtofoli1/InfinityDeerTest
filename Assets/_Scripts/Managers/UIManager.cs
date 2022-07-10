using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentPoints;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverPoints;
    public TextMeshProUGUI hiScoreText;
    
    public void UpdatePoints()
    {
        currentPoints.text = GameManager.instance.player.points.ToString();
    }

    public void EndGameScreen(bool timeOver = false)
    {
        //Tween Alpha
        gameOverScreen.SetActive(true);
        if (timeOver)
        {
            gameOverText.text = "TIME OVER";
        }
        else
        {
            gameOverText.text = "GAME OVER";
        }

        gameOverPoints.text = GameManager.instance.player.points.ToString();
        hiScoreText.text = PlayerPrefs.GetInt("HiScore").ToString();
    }
}