using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeStartState : MonoBehaviour, IBikeState
{
    private BikeController _bikeController;
    public void Handle(BikeController bikeController)
    {
        if (!_bikeController)
            _bikeController = bikeController;

        _bikeController.CurrentSpeed = _bikeController.maxSpeed;
    }

    private void FixedUpdate()
    {
        if (!_bikeController)
            return;
        if (_bikeController.CurrentSpeed <= 0f)
            return;
        _bikeController.transform.Translate(
            Vector3.forward * (_bikeController.CurrentSpeed * Time.fixedDeltaTime));
        
    }
}
