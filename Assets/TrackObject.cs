using UnityEngine;

public class TrackObject : MonoBehaviour
{
    [SerializeField] public float speed;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }
}