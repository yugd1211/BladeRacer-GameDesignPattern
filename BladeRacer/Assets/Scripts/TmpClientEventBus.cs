using System;
using EventBus;
using Unity.VisualScripting;
using UnityEngine;

public class TmpClientEventBus : MonoBehaviour
{
    private bool _isButtonEnabled;

    private void Start()
    {
        gameObject.AddComponent<HUDController>();
        gameObject.AddComponent<CountdownTimer>();
        gameObject.AddComponent<BikeController>();

        _isButtonEnabled = true;
    }

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.STOP, Restart);
    }

    private void Restart()
    {
        _isButtonEnabled = false;
    }

    private void OnGUI()
    {
        if (!_isButtonEnabled)
            return;
        if (!GUILayout.Button("Start CountDown"))
            return;
        RaceEventBus.Publish(RaceEventType.COUNTDOWN);
        _isButtonEnabled = false;
    }
}
