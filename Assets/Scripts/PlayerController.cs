using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    private float moveX;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
    }
    
    private void FixedUpdate()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            moveX = Input.acceleration.x;
            rb.velocity = new Vector2(Input.acceleration.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            Vector2 velocity = rb.velocity;
            velocity.x = moveX;
            rb.velocity = velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            ChangeDirection();
        }
    }
    public void ChangeDirection()
    {
        rb.transform.position = transform.position;
        if (rb.transform.position.x > 0)
        {
            rb.transform.position = new Vector2(-rb.transform.position.x, rb.transform.position.y);
        }
        else if (rb.transform.position.x < 0)
        {
            rb.transform.position = new Vector2(rb.transform.position.x - ((0 + rb.transform.position.x)*2), rb.transform.position.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            SceneManager.LoadScene(0);
        }
    }
}
