using UnityEngine;

namespace Collectable
{
    public class Collectable : MonoBehaviour
    {
        public static int count { get; private set; } = 0;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                count++;
                Debug.Log("item collected" + count);
                Destroy(gameObject);
            }
        }
    }
}
