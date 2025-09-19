using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager scoreManager;  

    public TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (scoreManager == null)
        {
            scoreManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void AddScore(int pts)
    {
        score += pts;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{score}";
        }
    }
}
