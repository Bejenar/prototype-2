using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Unit_Selector;
using Song_Selector;
using Unity.VisualScripting;
using UnityEngine;

public class PersistentConfig : MonoBehaviour
{

    private static PersistentConfig _instance;
    public static PersistentConfig Instance => _instance;


    
    public SongSO selectedSong;
    
    public SelectedUnitItem selectedUnitItem; 
    // array of selected units 
    public UnitSO[] selectedUnits = new UnitSO[5];
    
    
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
