using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private bool _isDisplayOn;

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
    }

    private void DisplayHUD()
    {
        _isDisplayOn = true;
    }

    private void OnGUI()
    {
        if (!_isDisplayOn)
            return;
        if (GUILayout.Button("STOP Race"))
            RaceEventBus.Publish(RaceEventType.STOP);
    }
}
