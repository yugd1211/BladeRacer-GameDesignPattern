using System;
using EventBus;
using Unity.VisualScripting;
using UnityEngine;

public enum Direction
{
    Left = -1,
    Right = 1,
}

public class BikeController : MonoBehaviour
{
    private bool _isTurboOn;
    private float _distance = 1.0f;
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;
    
    public float CurrentSpeed { get; set; }
    public Direction CurrentTurnDirection { get; set; }
    private IBikeState _startState, _stopState, _turnState;
    private BikeStateContext _context;

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
    }

    private void OnDisable()
    {
        RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
        RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);
    }

    private void Start()
    {
        _context = new BikeStateContext(this);

        _startState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTrunState>();
        
        _context.Transition(_stopState);
    }

    public void ToggleTurbo()
    {
        _isTurboOn = !_isTurboOn;
        Debug.Log("Turbo Active: " + _isTurboOn);
    }
    
    public void StartBike() => _context.Transition(_startState);
    public void StopBike() => _context.Transition(_stopState);
    public void Turn(Direction direction)
    {
        // CurrentTurnDirection = direction;
        // _context.Transition(_turnState);
        transform.Translate(direction == Direction.Left ? Vector3.left : Vector3.right * _distance);
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }
}
