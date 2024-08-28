using UnityEngine;

public enum Direction
{
    Left = -1,
    Right = 1,
}

public class BikeController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;
    
    public float CurrentSpeed { get; set; }
    public Direction CurrentTurnDirection { get; set; }

    private IBikeState _startState, _stopState, _turnState;

    private BikeStateContext _context;

    private void Start()
    {
        _context = new BikeStateContext(this);

        _startState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTrunState>();
        
        _context.Transition(_stopState);
    }

    public void StartBike() => _context.Transition(_startState);
    public void StopBike() => _context.Transition(_stopState);
    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;
        _context.Transition(_turnState);
    }
}
