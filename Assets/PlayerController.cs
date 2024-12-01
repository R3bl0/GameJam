using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        transform.position = PlayerState.PlayerPosition;
    }

    public void SavePlayerPosition()
    {
        PlayerState.PlayerPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SavePlayerPosition(); 
            SwitchScene(); 
        }
    }

    void SwitchScene()
    {
        PlayerState.IsTopDown = !PlayerState.IsTopDown;
        
        string nextScene = PlayerState.IsTopDown ? "TD1" : "SV1";
        
        SceneManager.LoadScene(nextScene);
    } 
}
