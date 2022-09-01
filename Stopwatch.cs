
using TMPro;
using UnityEngine;
using System;
using System.Collections;

public class Stopwatch : MonoBehaviour
{
    private float currentTime;
    public TextMeshProUGUI timeText;
    private bool stopwatchRunning;
    public float highScore;
    private TimeSpan time;
    private TimeSpan tempTimeSpan;
    private float delay = 1.5f;
    void Start()
    {
        currentTime = 0;
        timeText.text = "00:00:00";
        time = TimeSpan.Zero;
        // PlayerPrefs.DeleteKey("High Score");
        highScore = PlayerPrefs.GetFloat("High Score");
        StartStopwatchWithDelay();
    }

    public IEnumerator StopwatchCoroutine()
    {
        // print("running");
        while (stopwatchRunning)
        {
            currentTime += Time.deltaTime;
            time = TimeSpan.FromSeconds(currentTime);
            PrintTime(time,timeText);
            yield return new WaitForSeconds(0.001f);
        }
    }

    public void StartStopwatch()
    {
        stopwatchRunning = true;
        StartCoroutine(StopwatchCoroutine());
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(delay);
        StartStopwatch();
    }

    public void StartStopwatchWithDelay()
    {
        StartCoroutine(DelayStart());
    }
    public void StopStopwatch()
    {
        stopwatchRunning = false;
        StopCoroutine(StopwatchCoroutine());
        UpdateHighScore();
    }
    public void PrintCurrentTime(TextMeshProUGUI textBox)
    {
        textBox.text = time.ToString(@"mm\:ss\:ff"); //the format to display the time, in shortcut form
    }
    public void PrintTime(TimeSpan timespan, TextMeshProUGUI textBox = null)
    {
        if (textBox) textBox.text = timespan.ToString(@"mm\:ss\:ff"); //the format to display the time, in shortcut form
        else timeText.text = timespan.ToString(@"mm\:ss\:ff");
    }

    public void PrintTime(float milisecs, TextMeshProUGUI textBox = null)
    {
        tempTimeSpan = TimeSpan.FromMilliseconds(milisecs);
        if (textBox) textBox.text = tempTimeSpan.ToString(@"mm\:ss\:ff");
        else timeText.text = tempTimeSpan.ToString(@"mm\:ss\:ff");
    }
    public void UpdateHighScore()
    {
        if (time.TotalMilliseconds <= highScore) return;
        highScore = (float)time.TotalMilliseconds;
        print("time.m =" + time.Milliseconds);
        PlayerPrefs.SetFloat("High Score", highScore);
    }
    public void PrintHighScore(TextMeshProUGUI textBox)
    {
        PrintTime(highScore,textBox);
        print("high score in mil =" + highScore);
    }
}
