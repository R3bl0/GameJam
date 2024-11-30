using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject platformerPlayerPrefab;
    public GameObject topDownPlayerPrefab;

    void Start()
    {
        GameObject playerToSpawn;

        if (PlayerState.IsTopDown)
        {
            playerToSpawn = topDownPlayerPrefab;
        }
        else
        {
            playerToSpawn = platformerPlayerPrefab;
        }
        
        Instantiate(playerToSpawn, transform.position, Quaternion.identity);
    }
}
