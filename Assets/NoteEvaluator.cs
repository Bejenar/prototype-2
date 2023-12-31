using UnityEngine;

public abstract class NoteEvaluator : MonoBehaviour
{
    protected ScoreManager _scoreManager;
    [SerializeField] public int scoreMultiplier = 100;
    
    protected virtual void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }
    
    public abstract void Evaluate(GoalChecker.InputData inputData);

    public abstract NoteType GetNoteType();
}