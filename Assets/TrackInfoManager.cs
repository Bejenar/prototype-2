using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackInfoManager : MonoBehaviour
{
    [SerializeField] private Slider[] sliders;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            var selectedSong = PersistentConfig.Instance.selectedSong;
            var timing = selectedSong.ultimateTimings[i];
            sliders[i].value = timing;
            sliders[i].transform.GetComponentInChildren<TextMeshProUGUI>().text =
                ((int)(selectedSong.audioClip.length * timing)).ToString();
        }
    }
}