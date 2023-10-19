using System.Linq;
using UnityEngine;

class HoldNoteEvaluator : NoteEvaluator
{
    [SerializeField] private int scoreMultiplier;

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
            _startTileAccuracy = CalculateAccuracy(_startTile.transform.position);
        }

        if ((_started && !inputData.pressedThisFrame) || _passedEndTile)
        {
            Debug.Log("Evaluating Hold End");
            EvaluateHoldEnd();
            Destroy(inputData.currentTile);
        }
    }

    private void EvaluateHoldEnd()
    {
        _endTileAccuracy = _endTile ? CalculateAccuracy(_endTile.transform.position) : 0f;

        var meanAccuracy = new[] { _startTileAccuracy, _endTileAccuracy }.Average();
        _scoreManager.AddScore(CalculateScore(meanAccuracy));

        _started = false;
        _passedEndTile = false;
    }

    private int CalculateScore(float accuracy)
    {
        return (int)(scoreMultiplier * accuracy);
    }

    private float CalculateAccuracy(Vector2 tilePos)
    {
        return 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.name)
        {
            case "Start":
                _startTile = col.gameObject;
                break;
            case "End":
                _endTile = col.gameObject;
                _passedEndTile = true;
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
                _endTile = col.gameObject == _endTile ? null : _endTile;
                break;
        }
    }

    public override NoteType GetNoteType() => NoteType.HOLD;
}