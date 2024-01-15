using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager2 : MonoBehaviour
{
    [SerializeField] private List<Transform> transforms;
    [SerializeField] private GameObject car;

    private bool enableSpawn;

    [SerializeField] private float spawnTime;

    private bool stopSpawn;
    private void OnEnable()
    {
        StartCoroutine(Spawn());
        TrafficLight.OnStopVehicle += StopSpawn;
    }

    private void StopSpawn()
    {
        stopSpawn = true;
    }

    private IEnumerator Spawn()
    {
        while (!stopSpawn)
        {
            GameObject carLeft = Instantiate(this.car);
            carLeft.transform.position = transforms[0].position;
            carLeft.transform.rotation = Quaternion.Euler(0, 0, -90);

            GameObject carTop = Instantiate(this.car);
            carTop.transform.position = transforms[1].position;
            carTop.transform.rotation = Quaternion.Euler(0, 0, 180);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
