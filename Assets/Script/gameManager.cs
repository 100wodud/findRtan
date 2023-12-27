using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject rain;
    public GameObject panel;
    public GameObject rtan;

    public static gameManager I;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    int totalScore;
    float limit = 4f;

    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        initGame();
        InvokeRepeating("makeRain", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit < 0)
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            limit = 0.0f;
        }

        timeText.text = limit.ToString("N2");
    }
    void makeRain()
    {
        Instantiate(rain);
    }    
    
    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }
    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void initGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        limit = 4f;
    }
}
