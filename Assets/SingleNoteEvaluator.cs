using System;
using UnityEngine;

class SingleNoteEvaluator : NoteEvaluator
{
    public override void Evaluate(GoalChecker.InputData inputData)
    {
        if (inputData.performedThisFrame)
        {
            var tile = inputData.currentTile;
            var score = (int) (CalculateAccuracy(tile.transform.position) * 100);
            _scoreManager.AddScore(score);
            Destroy(inputData.currentTile);
        }
    }

    private float CalculateAccuracy(Vector2 tilePos)
    {
        var dif = Math.Abs(tilePos.y - transform.position.y);
        var accuracy = dif switch
        {
            < 0.2f => 1.0f,
            < 0.75f => 0.75f,
            < 1.2f => 0.5f,
            _ => 0f
        };
        
        return accuracy;
    }

    public override NoteType GetNoteType() => NoteType.SINGLE;
}