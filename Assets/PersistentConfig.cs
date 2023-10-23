using System.Collections;
using System.Collections.Generic;
using Song_Selector;
using Unity.VisualScripting;
using UnityEngine;

public class PersistentConfig : MonoBehaviour
{

    private static PersistentConfig _instance;
    public static PersistentConfig Instance => _instance;
    
    
    public SongSO selectedSong;
    
    // array of selected units 
    // 
    
    
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
