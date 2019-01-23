using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PostAreaColor))]
public class ColorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PostAreaColor colorScript = (PostAreaColor)target;

        if (GUILayout.Button("Change Color Randomly"))
        {
            colorScript.SetRandomColor();
        }

    }

}
