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
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
    public void OnLeftButtonDown()
    {
        rb.transform.position = new Vector2(rb.transform.position.x - 1f, rb.transform.position.y);
    }
    public void OnRightButtonDown()
    {
        rb.transform.position = new Vector2(rb.transform.position.x + 1f, rb.transform.position.y);
    }
    public void OnButtonUp()
    {
        rb.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y);
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
            SceneManager.LoadScene(1);
        }
    }
}
