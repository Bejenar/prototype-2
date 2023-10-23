using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalChecker : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Dictionary<NoteType, NoteEvaluator> _noteEvaluators;

    private bool _performedThisFrame;
    private bool _pressedThisFrame;
    private bool _releasedThisFrame;
    private GameObject _currentTile;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _noteEvaluators = GetComponents<NoteEvaluator>()
            .ToDictionary(e => e.GetNoteType(), e => e);
    }

    // Update is called once per frame
    void Update()
    {
        if (_performedThisFrame)
        {
            StartCoroutine(ChangeAlpha());
            Debug.Log("Performed " + name);
        }

        if (_pressedThisFrame)
        {
            Debug.Log("Pressed " + name);
        }

        if (_releasedThisFrame)
        {
            Debug.Log("Released " + name);
        }


        if (_currentTile)
        {
            _noteEvaluators[_currentTile.GetComponent<TileObject>().Type].Evaluate(buildInputData());
        }

        ResetFlags();
    }


    private void ResetFlags()
    {
        _performedThisFrame = false;
        _releasedThisFrame = false;
    }

    public void OnPressed(InputAction.CallbackContext ctx)
    {
        _performedThisFrame = ctx.action.WasPerformedThisFrame();
        _pressedThisFrame = ctx.action.WasPressedThisFrame();
        _releasedThisFrame = ctx.action.WasReleasedThisFrame();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<TileObject>())
        {
            return;
        }

        _currentTile = other.gameObject;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (_currentTile == other.gameObject)
        {
            _currentTile = null;
            if (other.gameObject.activeSelf)
            {
                EventBus.Trigger("combo-event", 0.0f);
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator ChangeAlpha()
    {
        var color = _spriteRenderer.color;
        color.a = 1;

        _spriteRenderer.color = color;

        yield return new WaitForSeconds(0.2f);

        color.a = 0;
        _spriteRenderer.color = color;
    }

    private InputData buildInputData()
    {
        return new InputData(_performedThisFrame, _pressedThisFrame, _currentTile);
    }

    public record InputData(bool performedThisFrame, bool pressedThisFrame, GameObject currentTile);
}