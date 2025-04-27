using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    [SerializeField]GameObject gameOverPanel;
    void Start()
    {
        gameOverPanel.SetActive(false);  
    }

    public void GameOverSeq()
    {
        StartCoroutine(GameOverAnim());
    }

    IEnumerator GameOverAnim()
    {
        yield return new WaitForSeconds(1);
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
