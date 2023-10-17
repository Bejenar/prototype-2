using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class HoldTile : MonoBehaviour
{
    
    private float length = 10;

    private SpriteRenderer _pathSpriteRenderer;
    private BoxCollider2D _pathCollider; 
    
    public void Initialize()
    {
        Debug.Log("Test");

        var path = gameObject.transform.Find("Path");
        var end = gameObject.transform.Find("End");
        _pathSpriteRenderer = path.GetComponent<SpriteRenderer>();
        _pathCollider = gameObject.GetComponent<BoxCollider2D>();

        _pathSpriteRenderer.size = new Vector2(3.5f, length);
        _pathCollider.offset = new Vector2(0, length / 2);
        _pathCollider.size = new Vector2(1, length + 1);

        path.localPosition = new Vector2(0, length);
        end.localPosition = new Vector2(0, length);
    }

    public void Initialize(float length)
    {
        this.length = length;
        Initialize();
    }
}
