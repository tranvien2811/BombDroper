using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AstarAi))]
public class AirEditor : Editor
{
    private AstarAi astarAi;

    public override void OnInspectorGUI()
    {
        astarAi = (AstarAi)target;
        base.OnInspectorGUI();
        if (GUILayout.Button("Chage Editor"))
        {
            astarAi.SetUpMoveAi();
        }
    }
}
