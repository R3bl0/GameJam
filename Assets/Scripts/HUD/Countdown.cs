using TMPro;
using UnityEngine;

namespace HUD
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] float remainingTime;
        void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime = Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
                // GameOver();
            }
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}