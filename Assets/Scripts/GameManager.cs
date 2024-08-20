using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button startGame;
    public GameObject worldMap;
    public GameObject titleScreen;
    public Camera camera2;
    public Button restartGame;
    public Button winRetryGame;
    
    
    public ObjectPool objectPool;
    void Start()
    {
        objectPool.CreatePooledObjects();
        startGame.onClick.AddListener(StartGame);
        restartGame.onClick.AddListener(RestartGame);
        winRetryGame.onClick.AddListener(RestartGame);
    }

    public void StartGame()
    {
        worldMap.SetActive(true);
        camera2.enabled = false;
        titleScreen.SetActive(false);
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
