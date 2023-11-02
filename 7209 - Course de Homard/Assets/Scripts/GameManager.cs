using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameMode gameMode { get; private set; }

    /// <summary>
    /// Singleton
    /// </summary>
    public static GameManager Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Home))
        {
            GoToMainMenu();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeGameMode(GameMode newGameMode)
    {
        gameMode = newGameMode;
    }
}

public enum GameMode
{
    PLAY,
    PAUSE
}
