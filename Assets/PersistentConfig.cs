using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.CompilerServices.Unit_Selector;
using Song_Selector;
using UnityEngine;

public class PersistentConfig : MonoBehaviour
{
    private static PersistentConfig _instance;
    public static PersistentConfig Instance => _instance;


    public SongSO selectedSong;

    public SelectedUnitItem selectedUnitItem;

    // array of selected units 
    public UnitSO[] selectedUnits = new UnitSO[5];

    public Dictionary<Accuracy, int> accuracyStats;
    public int combo = 0;
    public int score = 0;


    void Awake()
    {
        if (_instance)
        {
            _instance.selectedUnits = new UnitSO[5];
            Destroy(this);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}