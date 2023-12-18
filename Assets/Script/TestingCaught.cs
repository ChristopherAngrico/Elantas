using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCaught : MonoBehaviour
{
    private List<Car> carList = new List<Car>();
    private void Update()
    {
        if (GameObject.Find("Car1") != null)
        {
            Car car = GameObject.Find("Car1").GetComponent<Car>();
            carList.Add(car);
            print(carList.Count);
        }
    }
}
