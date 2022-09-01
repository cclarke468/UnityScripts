using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    public UnityEvent awakeEvent;
    public GameObject shader;
    private float delay = 2f;
    private void Awake()
    {
        Time.timeScale = 0;
        awakeEvent.Invoke();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ReloadGameWithDelay()
    {
        shader.SetActive(true);
        StartCoroutine(DelayedReload());
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        // print("game over");
    }

    public void DisplayLog()
    {
        
    }

    private IEnumerator DelayedReload()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
