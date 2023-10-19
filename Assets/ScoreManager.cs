using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;

    private int _score;
    private int Score
    {
        get => _score;
        set
        {
            _score = value;
            scoreLabel.text = _score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void AddScore(int score)
    {
        Score += score;
        Debug.Log("Scored" + score);
    }
}