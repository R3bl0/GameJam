using UnityEngine;

namespace Engine
{
    public class GameEnd : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (Collectable.Collectable.count == 4)
                {
                    Debug.Log("Koniec gry");
                }
                else
                {
                    Debug.Log("Nie masz jeszcze wszystkich przedmiotów");
                }
            }
        }
    }
}
