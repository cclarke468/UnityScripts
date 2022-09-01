using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu()] 
public class VacuumCollectionSO : ScriptableObject
{
    public List<Collectable> suckedUpStuff;
    public int score;
    public int highScore;
    public int badCount;
    public int badLimit = 3;
    // public MainMenu scene;

    public void Start()
    {
        badCount = 0;
    }

    public void SuckUp(Collectable obj)
    {
        // suckedUpStuff.Add(obj);
        score += obj.value;
        if (obj.isBad)
        {
            badCount++;
            if (badCount == badLimit)
            {
                //needs to be action, not reference; this exact code is in main menu as well which is ineffective
                UpdateHighScore();
                badCount = 0;
                SceneManager.LoadScene("Game Over");
            }
            else if (badCount >= badLimit || badCount <= 0) badCount = 0;
            // Debug.Log("bad count = " + badCount);
        }
        // UpdateHighScore();
        // obj.isCollected = true;
        // Debug.Log("sucked!");
    }

    public void SpitOut(Collectable obj)
    {
        // for each thing in the collection list, 
        foreach (var collectedItem in suckedUpStuff.Where(collectedItem => collectedItem == obj))
        {
           // collectedItem.isCollected = false;
            suckedUpStuff.Remove(collectedItem);
        }
    }
    
    public void EmptyVacuum()
    {
        foreach (var collectedItem in suckedUpStuff)
        {
           // collectedItem.isCollected = false;
        }
        suckedUpStuff.Clear();
    }

    public void ResetInGameScore()
    {
        score = 0;
    }

    public bool UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            return true;
        }
        return false;
    }

    public int GetHighScorePref()
    {
        return highScore;
    }

    public void SetHighScorePref()
    {
         PlayerPrefs.SetInt("highScore", highScore);
    }
}
