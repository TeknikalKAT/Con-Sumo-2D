using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Text healthText;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDead = health <= 0;

        healthText.text = health.ToString();
    }
    public void HurtPlayer()
    {
        health -= 1;
    }
}
