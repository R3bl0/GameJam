using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ship;
    [SerializeField] private float cooldown = 60f;
    private Vector3 startPosition;
    private GameObject lastSpawnedShip;
    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(SpawnShips());
    }

    private IEnumerator SpawnShips()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(cooldown);
            Destroy(lastSpawnedShip);
        }
    }
    
    void Spawn()
    {
        GameObject spawned = Instantiate(ship, startPosition, Quaternion.identity);
        lastSpawnedShip = spawned;
    }
}
