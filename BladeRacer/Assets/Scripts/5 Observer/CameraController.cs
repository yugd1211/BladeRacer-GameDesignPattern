using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _5_Observer
{
    public class CameraController : Observer
    {
        private bool _isTurboOn;
        private Vector3 _initialPosition;
        private float _shakeMagnitude = 0.1f;
        private BikeController _bikeController;

        private void OnEnable()
        {
            _initialPosition = transform.localPosition;
        }

        private void Update()
        {
            if (_isTurboOn)
                transform.localPosition = _initialPosition + (Random.insideUnitSphere * _shakeMagnitude);
            else
                transform.localPosition = _initialPosition;
        }
        
        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController = subject.GetComponent<BikeController>();

            if (_bikeController)
                _isTurboOn = _bikeController.IsTurboOn;

        }
    }
}
