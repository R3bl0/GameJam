using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel; 

    private bool isPanelVisible = false;  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            isPanelVisible = !isPanelVisible;  
            panel.SetActive(isPanelVisible);  
        }
    }
}
