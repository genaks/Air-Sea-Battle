using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int pointsPerPlane = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI lastScoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    private int score = 0;
    private int highScore = 0;
    [SerializeField]
    private Color defaultScoreColor = new Color(255, 255, 255, 255);
    [SerializeField]
    private Color juicedScoreColor = new Color(0, 255, 0, 255);

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCountingScores(int hitScore)
    {
        score = 0;
        scoreText.text = "Score - " + score.ToString();
        pointsPerPlane = hitScore;
        scoreText.color = defaultScoreColor;
    }

    public void OnHit()
    {
        score += pointsPerPlane;
        scoreText.text = "Score - " + score.ToString();
        if (score > highScore)
        {
            scoreText.color = juicedScoreColor;
        }
    }

    public void StopCountingScores()
    {
        lastScoreText.text = "Previous score - " + score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High score - " + highScore.ToString();
        }
        score = 0;
    }

    public void UpdateHighScore(int defaultHighScore)
    {
        highScore = defaultHighScore;
        highScoreText.text = "High score - " + highScore.ToString();
    }
}
