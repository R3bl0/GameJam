using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 5, -10);
    public float followSpeed = 5f;

    private Transform target;

    private void Start()
    {
        FindPlayer();
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Nie znaleziono obiektu z tagiem 'Player'.");
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
