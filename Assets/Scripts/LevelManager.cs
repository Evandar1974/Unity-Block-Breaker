using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        int currentSceenIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceenIndex + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <=0)
        {
            LoadNextLevel();
        }
    }
}
