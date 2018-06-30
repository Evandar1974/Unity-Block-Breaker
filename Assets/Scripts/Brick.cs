using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHits;

    private int timeshit;

	// Use this for initialization
	void Start ()
    {
        timeshit = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timeshit++;
    }
}
