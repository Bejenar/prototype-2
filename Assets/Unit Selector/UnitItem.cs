using System.Runtime.CompilerServices.Unit_Selector;
using Song_Selector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unit_Selector
{
    public class UnitItem : MonoBehaviour
    {

        [SerializeField] private UnitSO unit;

        private void Start()
        {
            SetThumbnail(transform);
            SetName(transform);
        }

        public void OnClick()
        {
            Debug.Log("Clicked button " + name);
            PersistentConfig.Instance.selectedUnitItem.SelectUnit(unit);
        }

        private void SetThumbnail(Transform transform)
        {
            transform.Find("Thumbnail").GetComponent<Image>().sprite = unit.sprite;
        }

        private void SetName(Transform transform)
        {
            transform.Find("Name").GetComponent<TextMeshProUGUI>().text = unit.unitName;
        }
    }
    
    
}