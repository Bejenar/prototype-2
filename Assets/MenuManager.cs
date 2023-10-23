using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject[] menus;
    
    void Start()
    {
        
    }

    public void ToggleMenu(int index)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == index);
        }
    }
    
}
