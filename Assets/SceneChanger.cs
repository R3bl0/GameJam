using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject topDownPlayerPrefab;
    public GameObject platformerPlayerPrefab;
    public CameraFollow cameraFollow;
    [SerializeField] Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        anim.SetTrigger("shhh");
        anim.SetTrigger("end");

        GameObject player = Instantiate(newPlayerPrefab, Vector3.zero, Quaternion.identity);

        cameraFollow.SetTarget(player.transform);
    }
}
