using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Unit_Selector;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitItem : MonoBehaviour
{
    [SerializeField] private int itemIndex;

    private Image _image;

    private void Start()
    {
        _image = transform.GetComponentInChildren<Image>();
    }


    public void OnClick()
    {
        PersistentConfig.Instance.selectedUnitItem = this;
    }

    public void SelectUnit(UnitSO selectedUnit)
    {
        Debug.Log("Unit selected");
        _image.sprite = selectedUnit.sprite;
        PersistentConfig.Instance.selectedUnits[itemIndex] = selectedUnit;
    }
}
