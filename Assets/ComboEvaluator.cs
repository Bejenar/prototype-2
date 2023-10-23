using Unity.VisualScripting;
using UnityEngine;

public class ComboEvaluator : MonoBehaviour
{
    private int combo = 0;
    void Start()
    {
        EventBus.Register<float>("combo-event", OnComboEvent);
    }

    private void OnComboEvent(float accuracy)
    {
        if (accuracy >= 0.5f)
        {
            combo++;
        }
        else
        {
            combo = 0;
        }
        
        Debug.LogFormat("Combo is {0}", combo);
    }
}