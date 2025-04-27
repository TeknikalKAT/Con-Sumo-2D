using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    [Header("Wave Mechanics")]
    [SerializeField] GameObject[] spawners;
    [SerializeField] int scoreForChange;        //after what scores do we want to increase difficulty? 10, 20, 30??

    [Header("Stats Mechanics")]
    public static Score_Manager instance;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    int score = 0;
    int highScore = 0;

    bool isUpdating;
    Health_Manager healthManager;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreForChange = 150;
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "HighScore: " + highScore.ToString();
        healthManager = GetComponent<Health_Manager>();
      
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();

        //handles rate of spawning
        isUpdating = instance.score >= scoreForChange;

        if (isUpdating)
            IncreaseSpawnRate();

        if (score <= 0)
        {
            score = 0;
            
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        if (score > highScore)
            PlayerPrefs.SetInt("highscore", score);
        if(score <= 0)
        {
            healthManager.Die();
        }
    }

    void IncreaseSpawnRate()
    {
        foreach (var spawn in spawners)
        {
            spawn.GetComponent<Spawner>().DecreaseSpawnTime();
        }
        scoreForChange += 50;
    }

    public void ResetScore()
    {
        score = 100;
    }
    public int ReturnScore()
    {
        return score;
    }

  
}
