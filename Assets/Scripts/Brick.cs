using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public AudioClip broke;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public ParticleSystem Smoke;

    private LevelManager levelmanager;
    private int timeshit;
    private bool isBreakable;

    // Use this for initialization
    void Start ()
    {
        isBreakable = (this.tag == "Breakable");
        //track brakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timeshit = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
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
            AudioSource.PlayClipAtPoint(broke, transform.position);
            breakableCount--;
            levelmanager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

    }

    void PuffSmoke()
    {
        ParticleSystem.Instantiate(Smoke, transform.position, Quaternion.identity);
        var main = Smoke.main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        ParticleSystem.Destroy(Smoke, main.duration);
    }

    void LoadSprites()
    {
        int spriteIndex = timeshit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick Sprite Missing!!!");
        }
    }
}
