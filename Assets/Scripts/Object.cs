using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Object : MonoBehaviour
{
    [SerializeField] float minSize = 0.5f;
    [SerializeField] float maxSize = 1.5f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float minSpeed = 5f;
    [SerializeField] int maxPoints = 25;
    [SerializeField] int minPoints = 5;

    [SerializeField]int points;
    [SerializeField] bool killerObject;
    [SerializeField] bool goodFood;

    float moveSpeed;
    Rigidbody2D rb;
    Audio_Manager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        audioManager = Score_Manager.instance.GetComponent<Audio_Manager>();
        
        RandomSize();
    }


    private void FixedUpdate()
    {
        
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (killerObject)
            {
                Score_Manager.instance.GetComponent<Health_Manager>().Die();
            }
            else
            {
                if (goodFood)
                {
                    Score_Manager.instance.AddPoints(points);
                    int soundIndex = Random.Range(0, audioManager.biteSounds.Length);

                    audioManager.PlaySFX(audioManager.biteSounds[soundIndex]);
                }
                else
                {
                    int soundIndex = Random.Range(0, audioManager.badFoodSounds.Length);
                    Score_Manager.instance.AddPoints(-points);
                    audioManager.PlaySFX(audioManager.badFoodSounds[soundIndex]);
                }

            }
            Destroy(gameObject);
        }
    }
    void RandomSize()
    {
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector2(size, size);

        points = Mathf.RoundToInt(((size - minSize) / (maxSize - minSize)) * (maxPoints - minPoints) + minPoints);

    }
}
