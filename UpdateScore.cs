using TMPro;
using UnityEngine;


public class UpdateScore : MonoBehaviour
{
    //turn into game action
    public VacuumCollectionSO scoreSO;
    public TextMeshProUGUI scoreTextBox;
    public TextMeshProUGUI highScoreTextBox;
    public GameObject newHighScore;
    
    private void Awake()
    {
        if (scoreTextBox != null)
        {
            UpdateScoreText();
        } 
        if (highScoreTextBox != null)
        {
            UpdateHighScoreText();
        } 
        
    }
    private void UpdateScoreText()
    {
        scoreTextBox.text = scoreSO.score.ToString();
    }
    
    private void UpdateHighScoreText()
    {
        highScoreTextBox.text = scoreSO.highScore.ToString();
        if (scoreSO.UpdateHighScore()) newHighScore.SetActive(true);
    }
    
//coroutine instead
    // private void LateUpdate()
    // {
    //     UpdateScoreText();
    //     UpdateHighScoreText();
    // }
}
