using UnityEngine;

namespace Scrips
{
    public class BulletTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                ObstacleHit obstacle = other.GetComponent<ObstacleHit>();
                if (obstacle != null)
                {
                    obstacle.RegisterHit();
                }

                Destroy(gameObject); // Huỷ viên đạn
            }
        }
    }
}