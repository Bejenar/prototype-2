using UnityEngine;

public abstract class NoteEvaluator : MonoBehaviour
{
    public abstract void Evaluate(GoalChecker.InputData inputData);

    public abstract NoteType GetNoteType();
}