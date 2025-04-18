using TMPro;
using UnityEngine;

namespace Scrips
{
    public class ObstacleWithCounter : MonoBehaviour
    {
        public int hitPoints = 10;
        public TextMeshPro textDisplay;

        private void Start()
        {
            UpdateDisplay();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                hitPoints--;
                UpdateDisplay();

                if (hitPoints <= 0)
                {
                    Destroy(gameObject);
                }

                Destroy(collision.gameObject);
            }
        }

        void UpdateDisplay()
        {
            if (textDisplay != null)
                textDisplay.text = hitPoints.ToString();
        }
    }
}