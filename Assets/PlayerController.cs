using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        // Ustawienie pozycji gracza na podstawie zapisanej pozycji
        transform.position = PlayerState.PlayerPosition;
    }

    public void SavePlayerPosition()
    {
        // Zapisanie aktualnej pozycji gracza w PlayerState
        PlayerState.PlayerPosition = transform.position;
    }

    void Update()
    {
        // Naciśnięcie klawisza "E" przełącza między scenami
        if (Input.GetKeyDown(KeyCode.E))
        {
            SavePlayerPosition(); // Zapisujemy pozycję przed przejściem do innej sceny
            SwitchScene(); // Przełączamy scenę
        }
    }

    void SwitchScene()
    {
        // Ustawiamy tryb gry
        PlayerState.IsTopDown = !PlayerState.IsTopDown;

        // Wybór odpowiedniej sceny
        string nextScene = PlayerState.IsTopDown ? "TD1" : "SV1";

        // Przełączanie sceny
        SceneManager.LoadScene(nextScene);
    } 
}
