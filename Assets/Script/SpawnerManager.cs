using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<Transform> transforms;
    [SerializeField] private GameObject car;

    private bool enableSpawn;

    [SerializeField] private float spawnTime;
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            GameObject carLeft = Instantiate(this.car);
            carLeft.transform.position = transforms[0].position;
            carLeft.transform.rotation = Quaternion.Euler(0, 0, -90);

            GameObject carRight = Instantiate(this.car);
            carRight.transform.position = transforms[1].position;
            carRight.transform.rotation = Quaternion.Euler(0, 0, 90);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
