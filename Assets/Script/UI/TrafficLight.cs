using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public delegate void TrafficLightDelegate();
    public static event TrafficLightDelegate OnStopVehicle;

    public void StopVehicle()
    {
        OnStopVehicle?.Invoke();
    }
}
