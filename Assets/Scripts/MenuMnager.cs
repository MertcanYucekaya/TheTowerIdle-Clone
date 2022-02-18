using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuMnager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI lastScore;
    private void Start()
    {
        if(PlayerPrefs.GetInt("lastScore") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("lastScore"));
        }
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        lastScore.text = PlayerPrefs.GetInt("lastScore").ToString();

    }
    public void playButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void shopButton()
    {
        SceneManager.LoadScene(2);
    }
}
