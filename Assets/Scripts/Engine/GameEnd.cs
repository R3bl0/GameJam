using UnityEngine;


namespace Engine
{
    public class GameEnd : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
        
            if (Collectable.Collectable.count == 4)
            {
                Debug.Log("Koniec gry");
            }
        }
    }
}
