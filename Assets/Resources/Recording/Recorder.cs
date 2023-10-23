using UnityEngine;
using UnityEngine.InputSystem;

public class Recorder : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject _tilePrefab;

    [SerializeField] private float speed = 10;

    public void OnRecord(InputAction.CallbackContext ctx)
    {
        Debug.Log("On record");
        
        if (!ctx.action.WasPerformedThisFrame())
            return;

        var newTile = Instantiate(_tilePrefab, _parent.transform, false);
        newTile.transform.Translate(Vector2.up * Time.timeSinceLevelLoad * speed);
    }
}