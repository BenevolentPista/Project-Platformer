using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public SpriteRenderer playerSprite;
    public bool entered;
    public GameObject gameOverScreen;

    public bool isAlive;
    public float jumpStrength;
    public float speed;
    public float horizontal;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        entered = false;
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded() && isAlive)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpStrength);
        }

        if (Input.GetButtonUp("Jump") && rigidbody.velocity.y > 0f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("GameOver"))
        {
            gameOverScreen.SetActive(true);
        }
    }
}
