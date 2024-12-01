using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ship;
    [SerializeField] private float cooldown = 60f;
    [SerializeField] private GameObject endPoint;
    private Vector3 startPosition;
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
        }
    }
    
    void Spawn()
    {
        GameObject spawned = Instantiate(ship, startPosition, Quaternion.identity);
        ShipFly shipFly = spawned.GetComponent<ShipFly>();
        
    }
}
