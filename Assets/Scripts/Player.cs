using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    Rigidbody2D rb;
    public static float health;
    public Animator animator;

    void Start()
    {
        health = 0.2f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
        PlayerRaycast();
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Prototype_1");
        }

    }
    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
    }
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player has collided with " + col.collider.name);
        if (col.gameObject.tag == "Terrain")
        {
            Debug.Log("Player has collided with " + col.collider.name);
            isGrounded = true;
        }
    }
    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit != null && hit.collider != null && hit.distance < .9f && hit.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            Destroy(hit.collider.gameObject);
        }
        if (hit != null && hit.collider != null && hit.distance < .9f && hit.collider.tag != "enemy")
        {
            
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Enemy") || col.gameObject.name.Equals("EnemyBat"))
        {
            health -= 0.03f;
        }
    }
}

