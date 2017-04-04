using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int lives = 10;
    public int money = 100;

    public Text LivesText;
    public Text MoneyText;

    public void loseLife(int l = 1)
    {
        lives -= l;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void Update()
    {
        MoneyText.text = "Money: $"+ money.ToString();
        LivesText.text = "Lives: " + lives.ToString();
    }

}
