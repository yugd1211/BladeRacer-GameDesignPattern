using System;
using UnityEngine;

namespace _5_Observer
{
    public class BikeController : Subject
    {
        public bool IsTurboOn { get; private set; }

        public float CurrentHealth { get { return health; } }

        private HUDController _hudController;
        private CameraController _cameraController;

        [SerializeField]
        private float health = 100.0f;
        private bool _isEngineOn;

        private void Awake()
        {
            _hudController = gameObject.AddComponent<HUDController>();
            _cameraController = FindObjectOfType<CameraController>();
        }

        private void Start()
        {
            StartEngine();
        }

        private void OnEnable()
        {
            if (_hudController)
                Attach(_hudController);
            
            if (_cameraController)
                Attach(_cameraController);
        }

        private void OnDisable()
        {
            
            if (_hudController)
                Detach(_hudController);
            
            if (_cameraController)
                Detach(_cameraController);
        }

        private void StartEngine()
        {
            _isEngineOn = true;
            NotifyObserver();
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn)
                IsTurboOn = !IsTurboOn;
            
            NotifyObserver();
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            IsTurboOn = false;
            NotifyObserver();
            
            if (health < 0)
                Destroy(gameObject);
        }
    }
}
