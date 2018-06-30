using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHits;
    private LevelManager levelmanager;
    private int timeshit;

	// Use this for initialization
	void Start ()
    {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timeshit = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timeshit++;
        SimulateWin();

    }

    void SimulateWin()
    {
        levelmanager.LoadNextLevel();

    }
}
