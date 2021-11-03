using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{

    public static SceneManagment Current;
    
    void Start()
    {
        Current = this;
    }

    
    void Update()
    {
        
    }

    public void ReloadLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenSceneIndex);
    }

    public void LoadNextLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currenSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
