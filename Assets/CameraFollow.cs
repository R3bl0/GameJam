using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Transform gracza
    public Vector3 offset;    // Przesunięcie kamery względem gracza
    public float smoothSpeed = 0.125f; // Szybkość wygładzania

    void LateUpdate()
    {
        if (player != null)
        {
            // Oblicz docelową pozycję kamery, uwzględniając offset
            Vector3 desiredPosition = player.position + offset;

            // Wygładzamy ruch kamery
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Ustawiamy pozycję kamery
            transform.position = smoothedPosition;
        }
    }
}
