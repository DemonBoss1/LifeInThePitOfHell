using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIDayControl : MonoBehaviour
{
    private int day = 1;
    [SerializeField] private TextMeshProUGUI textUp;
    public static UIDayControl DayControl;

    private void Awake()
    {
        DayControl = this;
        textUp.text = "Day " + day;
    }

    public void NextDay()
    {
        day++;
        textUp.text = "Day " + day;
    }
}
