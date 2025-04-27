using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float normalSpeed = 1000.0f;
    [SerializeField] float dragSpeed = 200f;
    [SerializeField] float normDrag = 10f;
    [SerializeField] float resetDrag = 0.2f;
    Input_Controller inputController;
    Animator anim;
    Rigidbody2D rb;

    [SerializeField] float moveSpeed;
    float _resetDrag;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TurnOnCollider());
        rb = GetComponent<Rigidbody2D>();
        inputController = GameObject.Find("Game Manager").GetComponent<Input_Controller>();
        anim = GetComponentInChildren<Animator>();
        _resetDrag = resetDrag;
        rb.drag = normDrag;
        if(Score_Manager.instance.ReturnScore() <= 0)
            Score_Manager.instance.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", inputController.horizontal);
        anim.SetFloat("Vertical", inputController.vertical);
        if (rb.drag != normDrag)
        {
            _resetDrag -= Time.deltaTime;
        }
        if (_resetDrag <= 0)
        {
            _resetDrag = resetDrag;
            moveSpeed = normalSpeed;
            rb.drag = normDrag;
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(inputController.horizontal, inputController.vertical).normalized;
        rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    IEnumerator TurnOnCollider()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        GetComponent<Collider2D>().enabled = true;
    }

    public void ThrowBackSpeed()
    {
        moveSpeed = dragSpeed;
    }

}
