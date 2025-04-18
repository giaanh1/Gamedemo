using UnityEngine;

namespace Scrips
{
    public class ObstacleHit : MonoBehaviour
    {
        [SerializeField] private int hitsToDestroy = 5;
        private int currentHits = 0;

        public void RegisterHit()
        {
            currentHits++;
            if (currentHits >= hitsToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}