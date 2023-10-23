using UnityEngine;

namespace Song_Selector
{
    [CreateAssetMenu(fileName = "Song", menuName = "Custom Menu/Song", order = 0)]
    public class SongSO : ScriptableObject
    {
        public string songName;
        public Sprite songImage;
        public AudioClip audioClip;
        public GameObject tilemapPrefab;
        public float[] ultimateTimings;
    }
}