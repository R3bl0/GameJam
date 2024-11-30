using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject playerPrefab2D;  // Prefab gracza dla sceny 2D
    public GameObject playerPrefabTopDown;  // Prefab gracza dla sceny top-down

    private GameObject currentPlayer;  // Aktualny obiekt gracza
    public Vector3 savedPosition = Vector3.zero;  // Ostatnia pozycja gracza
    public bool positionSaved = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayer(GameObject playerPrefab, Vector3 spawnPosition)
    {
        // Jeśli istnieje gracz z poprzedniej sceny, niszcz go
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }

        // Stwórz nowego gracza w odpowiedniej pozycji
        currentPlayer = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }

    public void SavePlayerPosition(Vector3 position)
    {
        savedPosition = position;
        positionSaved = true;
    }
}