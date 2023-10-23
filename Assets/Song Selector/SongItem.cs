using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Song_Selector
{
    public class SongItem : MonoBehaviour
    {

        [SerializeField] private SongSO song;

        private void Start()
        {
            SetThumbnail(transform);
            SetTitle(transform);
            SetDuration(transform);
        }

        public void OnClick()
        {
            Debug.Log("Clicked button " + name);
            var selectedField = GameObject.Find("Selected Song");
            PersistentConfig.Instance.selectedSong = song;
            SetThumbnail(selectedField.transform);
            SetTitle(selectedField.transform);
        }

        private void SetThumbnail(Transform transform)
        {
            transform.Find("Thumbnail").GetComponent<Image>().sprite = song.songImage;
        }

        private void SetTitle(Transform transform)
        {
            transform.Find("Title").GetComponent<TextMeshProUGUI>().text = song.songName;
        }

        private void SetDuration(Transform transform)
        {
            transform.Find("Length value").GetComponent<TextMeshProUGUI>().text = ((int)song.audioClip.length).ToString();
        }
    }
    
    
}