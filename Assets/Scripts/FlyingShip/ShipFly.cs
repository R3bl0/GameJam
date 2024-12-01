using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFly : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    private void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * speed));
    }
}
