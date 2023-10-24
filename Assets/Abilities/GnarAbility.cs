using System.Collections;
using System.Collections.Generic;
using Song_Selector;
using Unity.VisualScripting;
using UnityEngine;

public class GnarAbility : MonoBehaviour
{
    private ScoreManager _scoreManager;

    [SerializeField] private AudioClip gnarLine;
    [SerializeField] private GameObject shockwaveCenter;
    [SerializeField] private GameObject particle;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;

    [SerializeField] private Animator animator;
    private static readonly int Appear = Animator.StringToHash("appear");

    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        StartCoroutine(Activate());
    }


    public IEnumerator Activate()
    {
        AudioSource.PlayClipAtPoint(gnarLine, Camera.main.transform.position, 1.0f);
        animator.SetTrigger(Appear);

        var colliders = Physics2D.OverlapCircleAll(shockwaveCenter.transform.position, radius, layerMask);
        Debug.Log("found colliders: " + colliders.Length);
        foreach (var collider in colliders)
        {
            Debug.Log("Destroying " + collider.name);
            Instantiate(particle, collider.transform.position, Quaternion.identity);
            EventBus.Trigger("combo-event", 1f);
            _scoreManager.AddScore(collider.GetComponent<TileObject>().scoreMultiplier);
            Destroy(collider.gameObject);
        }
        // EventBus.Register("event", (SongSO so) => Debug.Log(so.songName));
        yield return new WaitForSeconds(0.1f);

    }
}
