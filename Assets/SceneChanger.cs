using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject topDownPlayerPrefab;  // Prefab gracza w Scene1
    public GameObject platformerPlayerPrefab;  // Prefab gracza w Scene2
    public CameraFollow cameraFollow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  // Sprawdzamy, czy naciśnięto "E"
        {
            if (SceneManager.GetActiveScene().name == "SV1")
            {
                ChangeScene("TD1", topDownPlayerPrefab);
            }
            else if (SceneManager.GetActiveScene().name == "TD1")
            {
                ChangeScene("SV1", platformerPlayerPrefab);
            }
        }
    }

    private void ChangeScene(string sceneName, GameObject newPlayerPrefab)
    {
        // Zniszczenie obecnego gracza w scenie
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }
        
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        
        GameObject player = Instantiate(newPlayerPrefab, Vector3.zero, Quaternion.identity);

        cameraFollow.player = player.transform;
    }
}
