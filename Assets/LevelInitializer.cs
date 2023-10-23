using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    private TrackObject _trackObject;

    private AudioSource _audioSource;

    void Start()
    {
        _trackObject = FindObjectOfType<TrackObject>();
        _audioSource = FindObjectOfType<AudioSource>();

        var song = PersistentConfig.Instance.selectedSong;
        Instantiate(song.tilemapPrefab, _trackObject.transform, false);
        _audioSource.clip = song.audioClip;
        _audioSource.Play();
    }
}