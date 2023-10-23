using TMPro;
using Unity.VisualScripting;
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
        var beforeScoringEvent = new BeforeScoringEvent(score);
        EventBus.Trigger("before-scoring", beforeScoringEvent);
        
        Score += beforeScoringEvent.Score;
        Debug.Log("Scored" + score);
    }

    public class BeforeScoringEvent
    {
        public int Score { get; set; }

        public BeforeScoringEvent(int score)
        {
            Score = score;
        }
    }
}