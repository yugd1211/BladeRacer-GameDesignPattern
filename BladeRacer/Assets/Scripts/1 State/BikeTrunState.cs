using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTrunState : MonoBehaviour, IBikeState
{
    private BikeController _bikeController;
    private Vector3 _turnDirection;

    public void Handle(BikeController bikeController)
    {
        if (!_bikeController)
            _bikeController = bikeController;

        _turnDirection.x = (float)_bikeController.CurrentTurnDirection;

        if (_bikeController.CurrentSpeed <= 0f)
            return;
        transform.Translate(_turnDirection * _bikeController.turnDistance);
    }
}
