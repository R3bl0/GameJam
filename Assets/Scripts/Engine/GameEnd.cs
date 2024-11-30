using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (Collectable.count == 4)
        {
            Debug.Log("Koniec gry");
        }
    }
}
