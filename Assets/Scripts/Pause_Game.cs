using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour
{
    [SerializeField]GameObject pauseMenu;

    bool isPaused = false;
    Input_Controller inputController;
    Game_Over gameOver;
    Health_Manager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        inputController = GetComponent<Input_Controller>();
        healthManager = GetComponent<Health_Manager>();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inputController.pause)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            if(healthManager.HealthLeft() > 0)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
