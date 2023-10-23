using UnityEngine;

public class TileObject : MonoBehaviour
{
    // [SerializeField] private float speed;
    [SerializeField] private NoteType type;

    public NoteType Type => type;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }
}