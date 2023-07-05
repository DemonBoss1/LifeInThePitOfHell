using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIDayControl : MonoBehaviour
{
    private int _day = 1;
    public int Day => _day;
    [SerializeField] private TextMeshProUGUI textUp;
    [SerializeField] private TextMeshProUGUI textPanel;
    public static UIDayControl DayControl;

    private void Awake()
    {
        DayControl = this;
        textUp.text = "Day " + _day;
        textPanel.text = "Day " + _day;
    }

    public void NextDay()
    {
        _day++;
        textUp.text = "Day " + _day;
        textPanel.text = "Day " + _day;
    }
}
