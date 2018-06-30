using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    
    public Sprite[] hitSprites;

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        bool isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            handleHits();
        }
    

    }

    void handleHits()
    {
        timeshit++;
        int maxHits = hitSprites.Length + 1;
        if (timeshit >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

    }

    void LoadSprites()
    {
        int spriteIndex = timeshit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    void SimulateWin()
    {
        levelmanager.LoadNextLevel();

    }
}
