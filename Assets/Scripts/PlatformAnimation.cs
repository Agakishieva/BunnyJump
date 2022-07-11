using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnimation : MonoBehaviour
{
    [SerializeField] private float t = 0;
    [SerializeField] private float Amp = 0.25f;
    [SerializeField] private float Freq = 2;
    [SerializeField] private float Offset = 0;
    [SerializeField] private Vector3 StartPos;


    [SerializeField] private Types type;
    public Types _type => type;

    public enum Types
    {
        normal,
        horizontal,
        vertical,
        destroyed
    }
    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        t = t + Time.deltaTime;
        Offset = Amp * Mathf.Sin(t * Freq);

        if (type == Types.normal)
        {
            transform.position = StartPos;
        }
        else if (type == Types.vertical)
        {
            transform.position = StartPos + new Vector3(0, Offset, 0);
        }
        else if (type == Types.horizontal)
        {
            transform.position = StartPos + new Vector3(Offset, 0, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Destroyed" && type == Types.destroyed)
        {
            Destroy(gameObject);
        }
    }
}

