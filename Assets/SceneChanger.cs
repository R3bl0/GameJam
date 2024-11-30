using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string otherSceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Zapisz pozycję gracza przed przejściem do nowej sceny
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                GameManager.Instance.SavePlayerPosition(player.transform.position);
            }

            // Przełącz na inną scenę
            SceneManager.LoadScene(otherSceneName);
        }
    }
}
