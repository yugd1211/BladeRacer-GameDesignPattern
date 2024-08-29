using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private Command _buttonA, _buttonD, _buttonW;
    private BikeController _bikeController;

    private void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _bikeController = gameObject.AddComponent<BikeController>();

        _buttonA = new TurnLeft(_bikeController);
        _buttonD = new TurnRight(_bikeController);
        _buttonW = new ToggleTurbo(_bikeController);
    }

    private void Update()
    {
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKeyUp(KeyCode.A))
                _invoker.ExecuteCommand(_buttonA);
            if (Input.GetKeyUp(KeyCode.D))
                _invoker.ExecuteCommand(_buttonD);
            if (Input.GetKeyUp(KeyCode.W))
                _invoker.ExecuteCommand(_buttonW);
            
        }
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Start Recording"))
        {
            _bikeController.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            _invoker.Record();
        }

        if (GUILayout.Button("Stop Recording"))
        {
            _bikeController.ResetPosition();
            _isRecording = false;
        }

        if (!_isRecording)
        {
            if (GUILayout.Button("Start Recording"))
            {
                _bikeController.ResetPosition();
                _isReplaying = true;
                _invoker.RePlay();
            }
        }
    }
}

