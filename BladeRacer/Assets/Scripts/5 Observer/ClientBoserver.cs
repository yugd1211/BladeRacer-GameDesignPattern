using System;
using Unity.VisualScripting;
using UnityEngine;

public class ClientBoserver : MonoBehaviour
{
    private _5_Observer.BikeController _bikeController;

    private void Start()
    {
        _bikeController = FindObjectOfType<_5_Observer.BikeController>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Damage Bike"))
        {
            if (_bikeController)
                _bikeController.TakeDamage(15.0f);
        }

        if (GUILayout.Button("Toggle Turbo"))
        {
            if (_bikeController)
                _bikeController.ToggleTurbo();
        }
    }
}
