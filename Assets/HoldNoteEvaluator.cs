using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

class HoldNoteEvaluator : NoteEvaluator
{
    private GameObject _startTile;
    private GameObject _endTile;

    private float _startTileAccuracy;
    private float _endTileAccuracy;

    private bool _started;
    private bool _passedEndTile;

    public override void Evaluate(GoalChecker.InputData inputData)
    {
        // Check if button pressed and triggered start tile 
        // Flag that started pressing 

        // If started pressing, check that button is still being hold 
        // If pressed and triggered end tile 
        // Evaluate accuracy 
        Debug.Log("Evaluating Event Triggered");

        if (inputData.performedThisFrame)
        {
            Debug.Log("Started Holding");
            _started = true;
            _startTileAccuracy = CalculateAccuracy(_startTile?.transform?.position);
        }

        if ((_started && !inputData.pressedThisFrame) || _passedEndTile)
        {
            Debug.Log("Evaluating Hold End With input data " + inputData + " _started and passed end tile: " + _started + _passedEndTile);
            EvaluateHoldEnd();
            inputData.currentTile.SetActive(false);
            Destroy(inputData.currentTile);
        }
    }

    private void EvaluateHoldEnd()
    {
        _endTileAccuracy = _endTile ? CalculateAccuracy(_endTile.transform.position) : 0f;

        var meanAccuracy = new[] { _startTileAccuracy, _endTileAccuracy }.Average();
        EventBus.Trigger("combo-event", meanAccuracy);
        _scoreManager.AddScore(CalculateScore(meanAccuracy));

        _startTile = null;
        _endTile = null;
        _started = false;
        _passedEndTile = false;
    }

    private int CalculateScore(float accuracy)
    {
        return (int)(scoreMultiplier * accuracy);
    }

    private float CalculateAccuracy(Vector2? tilePos)
    {
        return tilePos == null ? 0.0f : 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.name)
        {
            case "Start":
                _passedEndTile = false;
                _startTile = col.gameObject;
                break;
            case "End":
                _endTile = col.gameObject;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        switch (col.name)
        {
            case "Start":
                _startTile = col.gameObject == _startTile ? null : _startTile;
                break;
            case "End":
                if (col.gameObject == _endTile || _started)
                {
                    _endTile = null;
                    _passedEndTile = true;
                }
                break;
        }
    }

    public override NoteType GetNoteType() => NoteType.HOLD;
}