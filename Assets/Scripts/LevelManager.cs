using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int index;
    private int allSceneCount;

    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        allSceneCount = SceneManager.sceneCountInBuildSettings - 1;

    }
    public void NextLevel()
    {
        if (index < allSceneCount)
        {
            SceneManager.LoadScene(index + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(index);
    }
}
