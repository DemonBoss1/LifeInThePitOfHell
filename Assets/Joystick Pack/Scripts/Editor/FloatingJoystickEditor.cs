﻿using System.Collections;
using System.Collections.Generic;
using Joystick_Pack.Scripts.Joysticks;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloatingJoystick))]
public class FloatingJoystickEditor : JoystickEditor
{
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
}