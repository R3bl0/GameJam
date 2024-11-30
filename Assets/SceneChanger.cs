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
            // Zapisz pozycję gracza w GameManagerze
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                GameManager.Instance.SavePlayerPosition(player.transform.position);
            }

            // Przejdź do nowej sceny
            SceneManager.LoadScene(otherSceneName);
        }
    }
}
