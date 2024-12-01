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
                StartCoroutine(ChangeScene("TD1", topDownPlayerPrefab));
            }
            else if (SceneManager.GetActiveScene().name == "TD1")
            {
                StartCoroutine(ChangeScene("SV1", platformerPlayerPrefab));
            }
        }
    }

    private IEnumerator ChangeScene(string sceneName, GameObject newPlayerPrefab)
    {
        anim.SetTrigger("shhh");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        
        //yield return null;
        
        anim.SetTrigger("end");
        
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }

        GameObject player = Instantiate(newPlayerPrefab, Vector3.zero, Quaternion.identity);

        cameraFollow.SetTarget(player.transform);
    }
}
