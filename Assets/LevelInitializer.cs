using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        StartCoroutine(EndLevel(song.audioClip.length));
    }

    private IEnumerator EndLevel(float duration)
    {
        yield return new WaitForSeconds(duration + 1);

        SceneManager.LoadSceneAsync("Results");
    }
}