using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
        {
            Vector3 lastPosition = GameManager.Instance.lastPosition;
            if (lastPosition != Vector3.zero)
            {
                transform.position = lastPosition;
            }
        }
    }
}
