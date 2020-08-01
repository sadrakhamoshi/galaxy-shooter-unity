using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Sprite[] lives;
    [SerializeField]
    private Image displayLive;

    [SerializeField]
    private Image _startMenu;

    private const int enemyKillScore = 10;
    // we saved here becaues if saved in player after game object has been destroyed
    public int score;

    [SerializeField]
    private Text displayScore;

    public void UpdateLives(int currntLive)
    {
        displayLive.sprite = lives[currntLive];
    }
    public void UpdateScore()
    {
        score += enemyKillScore;
        displayScore.text = "Score : " + score;
    }

    
}
