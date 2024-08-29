using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeStateContext
{
    public IBikeState CurrentState { get; set; }
    private readonly BikeController _bikeController;

    public BikeStateContext(BikeController bikeController)
    {
        _bikeController = bikeController;
    }

    public void Transition()
    {
        CurrentState?.Handle(_bikeController);
    }
    
    
    public void Transition(IBikeState state)
    {
        CurrentState = state;
        CurrentState.Handle(_bikeController);
    }
}
