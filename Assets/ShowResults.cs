using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ShowResults : MonoBehaviour
{
    private TextMeshProUGUI _score;
    private TextMeshProUGUI _combo;
    private TextMeshProUGUI _perfect;
    private TextMeshProUGUI _good;
    private TextMeshProUGUI _meh;


    // Start is called before the first frame update
    void Start()
    {
        _score = GameObject.Find("Score_i").GetComponent<TextMeshProUGUI>();
        _combo = GameObject.Find("Combo_i").GetComponent<TextMeshProUGUI>();
        _perfect = GameObject.Find("Perfect_i").GetComponent<TextMeshProUGUI>();
        _good = GameObject.Find("Good_i").GetComponent<TextMeshProUGUI>();
        _meh = GameObject.Find("Meh_i").GetComponent<TextMeshProUGUI>();

        var results = PersistentConfig.Instance;

        _score.text = results.score.ToString();
        _combo.text = results.combo.ToString();
        _perfect.text = results.accuracyStats[Accuracy.PERFECT].ToString();
        _good.text = results.accuracyStats[Accuracy.GOOD].ToString();
        _meh.text = results.accuracyStats[Accuracy.MEH].ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}