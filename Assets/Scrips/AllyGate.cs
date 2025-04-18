using UnityEngine;

namespace Scrips
{
    public class AllyGate : MonoBehaviour
    {
        public int allyChange = 1; // âm hoặc dương

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FindObjectOfType<AllyManager>().ChangeAllyCount(allyChange);
                Destroy(gameObject); // hoặc animation phá huỷ
            }
        }
    }
}