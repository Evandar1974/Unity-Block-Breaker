using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Rigidbody2D rigi;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // lock ball to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse Clicked!");
                hasStarted = true;
                rigi.velocity = new Vector2(2f, 10f);
            }
        }
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.4f), Random.Range(0f, 0.4f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            rigi.velocity += tweak;
            
        }

    }
}
