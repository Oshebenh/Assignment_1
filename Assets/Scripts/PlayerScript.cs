// Lior Poterman 315368035 , Osher Ben Hamo 209264076.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    [SerializeField] bool isGrounded = false;
    [SerializeField] Rigidbody2D rb;
    Vector2 direction;
    public float gameDuration = 30f;
    public float timeRemaining;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No RigidBody has been found");
        }
        jumpForce = 7500f;
        rb.gravityScale = 13f;
        speed = 120f;
        timeRemaining = gameDuration;

    }

    // Update is called once per frame
    void Update()
    {

        direction = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            EndGame();
        }

    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
        }
    }

    void EndGame()
    {
        Debug.Log("The Game is Over");
    }

}