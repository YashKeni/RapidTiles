using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("Core Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void StartGameSceneFromMenu()
    {
        SceneManager.LoadScene("Core Game");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadHowToScene()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
