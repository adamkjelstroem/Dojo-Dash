using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UiPlacer))]
public class EditorUiPlacer : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UiPlacer uiPlacer = (UiPlacer)target;

        if (uiPlacer.rectTransoform == null || uiPlacer.target == null)
            return;

        uiPlacer.SetOffset();
        uiPlacer.SetPos();
    }


}
