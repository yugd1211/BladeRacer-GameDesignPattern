using System;
using UnityEngine;

public class TmpPlayerState : MonoBehaviour
{
    [SerializeField] private BikeController bikeController;

    private void Start()
    {
        bikeController = gameObject.AddComponent<BikeController>();
    }
    private void OnGUI()
    {
        if (GUILayout.Button("Start Bike"))
            bikeController.StartBike();
        if (GUILayout.Button("Turn Left Bike"))
            bikeController.Turn(Direction.Left);
        if (GUILayout.Button("Turn Right Bike"))
            bikeController.Turn(Direction.Right);
        if (GUILayout.Button("Stop Bike"))
            bikeController.StopBike();
    }
}
