using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumo_Bouncer : MonoBehaviour
{
    [SerializeField] float minSize = 0.5f;
    [SerializeField] float maxSize = 1.5f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float minSpeed = 5f;
    [SerializeField] float maxForce = 15f;
    [SerializeField] float minForce = 10f;
    float moveSpeed;
    Rigidbody2D rb;

    float bounceForce = 10f;

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

    void RandomSize()
    {
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector2(size, size);

        bounceForce = ((size - minSize) / (maxSize - minSize)) * (maxForce - minForce) + minForce;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector2 bounceDirection = (collision.collider.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 5f;
            collision.gameObject.GetComponent<Player_Controller>().ThrowBackSpeed();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            int soundIndex = Random.Range(0, audioManager.biteSounds.Length);

            audioManager.PlaySFX(audioManager.sumoPushes[soundIndex]);

        }
    }
}