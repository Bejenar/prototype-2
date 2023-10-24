using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ComboEvaluator : MonoBehaviour
{
    private int combo = 0;

    private Dictionary<Accuracy, int> _accuracyStats;

    private TextMeshProUGUI _comboLabel;

    void Start()
    {
        _accuracyStats = new Dictionary<Accuracy, int>();
        _accuracyStats.Add(Accuracy.GOOD, 0);
        _accuracyStats.Add(Accuracy.PERFECT, 0);
        _accuracyStats.Add(Accuracy.MEH, 0);
        EventBus.Register<float>("combo-event", OnComboEvent);

        _comboLabel = GameObject.Find("Combo Label").GetComponent<TextMeshProUGUI>();
        _comboLabel.text = combo.ToString();

        PersistentConfig.Instance.accuracyStats = _accuracyStats;
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
        _comboLabel.text = combo.ToString();
        PersistentConfig.Instance.combo = combo;
        CollectAccuracyStat(accuracy);
    }

    private void CollectAccuracyStat(float accuracy)
    {
        Accuracy result = accuracy switch
        {
            <= 0.5f => Accuracy.MEH,
            <= 0.75f => Accuracy.GOOD,
            _ => Accuracy.PERFECT
        };

        _accuracyStats[result]++;
    }
}