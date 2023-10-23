using UnityEngine;

namespace System.Runtime.CompilerServices.Unit_Selector
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Custom Menu/Unit")]
    public class UnitSO : ScriptableObject
    {
        public string unitName;
        public Sprite sprite;
        public GameObject unitPrefab;
    }
}