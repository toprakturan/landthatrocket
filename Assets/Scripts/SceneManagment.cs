using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{

    public static SceneManagment Current;
    public Text currentSceneText;
    private int currentSceneIndex;
    
    void Start()
    {
        Current = this;
        
    }

    
    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        changeSceneText();
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

    void changeSceneText()
    {
        currentSceneText.text = "Level: " + currentSceneIndex.ToString();
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void playAgainButton()
    {
        SceneManager.LoadScene(0);
    }

}
