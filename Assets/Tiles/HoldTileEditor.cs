using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HoldTile))]
public class HoldTileEditor : Editor
{
    private static int length = 10;   
    private void OnEnable()
    {
        
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var currentTile = this.target as HoldTile;


        EditorGUILayout.Space();
        
        length = EditorGUILayout.IntField("Length", length);

        if (GUILayout.Button("Reset"))
        {
            currentTile.Initialize(length);
        }
        
        if (GUILayout.Button("Clone"))
        {
            
            var newTile = Instantiate(currentTile.gameObject, currentTile.transform.parent, false);
            newTile.GetComponent<HoldTile>().Initialize(length);
        }
    }
}
