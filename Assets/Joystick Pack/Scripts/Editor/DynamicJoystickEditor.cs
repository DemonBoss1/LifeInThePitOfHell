using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DynamicJoystick))]
public class DynamicJoystickEditor : JoystickEditor
{
    private SerializedProperty _moveThreshold;

    protected override void OnEnable()
    {
        base.OnEnable();
        _moveThreshold = serializedObject.FindProperty("moveThreshold");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Background != null)
        {
            RectTransform backgroundRect = (RectTransform)Background.objectReferenceValue;
            backgroundRect.anchorMax = Vector2.zero;
            backgroundRect.anchorMin = Vector2.zero;
            backgroundRect.pivot = Center;
        }
    }

    protected override void DrawValues()
    {
        base.DrawValues();
        EditorGUILayout.PropertyField(_moveThreshold, new GUIContent("Move Threshold", "The distance away from the center input has to be before the joystick begins to move."));
    }
}