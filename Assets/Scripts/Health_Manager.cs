using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Manager : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Text healthText;
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float reviveTime = 3f;
    [SerializeField] GameObject deathPlayer;

    Game_Over gameOver;
    Audio_Manager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, spawnPoint.position, Quaternion.identity);
        gameOver = GetComponent<Game_Over>();
        audioManager = GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = health.ToString();
    }
    public void Die()
    {
        int soundIndex = Random.Range(0, audioManager.loseSounds.Length);
        audioManager.PlaySFX(audioManager.loseSounds[soundIndex]);

        Instantiate(deathPlayer, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
        Destroy(GameObject.FindWithTag("Player"));
        health -= 1;
        if (health > 0)
            Respawn();
        else
            GameOver();

    }

    void Respawn()
    {
        StartCoroutine(RevivePlayer());
    }

    IEnumerator RevivePlayer()
    {
        yield return new WaitForSeconds(reviveTime);
        Instantiate(player, spawnPoint.position, Quaternion.identity);
    }
    void GameOver()
    {
        gameOver.GameOverSeq();
    }
    public int HealthLeft()
    {
        return health;
    }


    
}
