using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel;  // Referencja do panelu UI

    private bool isPanelVisible = false;  // Czy panel jest widoczny

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))  // Jeśli naciśnięto "I"
        {
            isPanelVisible = !isPanelVisible;  // Przełącz widoczność panelu
            panel.SetActive(isPanelVisible);  // Ustaw widoczność panelu
        }
    }
}
