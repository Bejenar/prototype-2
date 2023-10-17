class HoldNoteEvaluator : NoteEvaluator
{
    public override void Evaluate(GoalChecker.InputData inputData)
    {
        // Check if button pressed and triggered start tile 
        // Flag that started pressing 
        
        // If started pressing, check that button is still being hold 
        // If pressed and triggered end tile 
        // Evaluate accuracy 
    }

    public override NoteType GetNoteType() => NoteType.HOLD;
}