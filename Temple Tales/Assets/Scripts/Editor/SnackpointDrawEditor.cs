﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Snackpointdrawer))]
public class SnackpointDrawEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space(25);

        if (GUILayout.Button("Create Snackpoints"))
        {
            Snackpointdrawer sd = (Snackpointdrawer)target;

            sd.CreateSnackpoints();
        }
        EditorGUILayout.Space(25);
    }
}
