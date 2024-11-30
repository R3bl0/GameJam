using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.positionSaved)
        {
            // Ustaw pozycję gracza na ostatnio zapisaną
            transform.position = GameManager.Instance.savedPosition;
        }
    }
}
