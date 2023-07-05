using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDayEvent : MonoBehaviour
{
    [SerializeField] float timeEvent = 1.0f;
    bool isEvent;
    float EventTimer;
    public static UIDayEvent DayEvent;

    [SerializeField] private GameObject eventPanel;

    private void Awake()
    {
        DayEvent = this;
    }
    public void PlayEvent()
    {
        eventPanel.SetActive(true);
        isEvent = true;
        Invoke("EndEvent", timeEvent);
    }
    private void EndEvent()
    {
        eventPanel.SetActive(false);
        isEvent = false;
    }
}
