using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Paddle paddle;
    private Rigidbody2D rigi;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
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
}
