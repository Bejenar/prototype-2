using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomuraAbility : MonoBehaviour
{
    private AudioSource _audioSource;
    private TrackObject _trackObject;

    [SerializeField] private AudioClip homuraLine;
    [SerializeField] private AudioClip slowSound;

    [SerializeField] private Animator animator;
    private static readonly int Appear = Animator.StringToHash("appear");

    void Start()
    {
        _trackObject = FindObjectOfType<TrackObject>();
        _audioSource = FindObjectOfType<AudioSource>();
        
        StartCoroutine(Activate());
    }


    public IEnumerator Activate()
    {
        AudioSource.PlayClipAtPoint(homuraLine, Camera.main.transform.position, 2.0f);
        AudioSource.PlayClipAtPoint(slowSound, Camera.main.transform.position);
        animator.SetTrigger(Appear);
        
        var initialSpeed = _trackObject.speed;
        
        _audioSource.pitch = 0.5f;
        _trackObject.speed /= 2;

        yield return new WaitForSeconds(5);

        _audioSource.pitch = 1;
        _trackObject.speed = initialSpeed;
    }

}
