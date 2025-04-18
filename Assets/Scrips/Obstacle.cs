using UnityEngine;

namespace Scrips
{
    public class Obstacle : MonoBehaviour
    {
        public int hitPoints = 3; // ✅ Số lần bị trúng đạn để phá hủy

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                hitPoints--;

                if (hitPoints <= 0)
                {
                    Destroy(gameObject); // ✅ Phá hủy obstacle
                }

                // ✅ Xoá đạn sau va chạm
                Destroy(collision.gameObject);
            }
        }
    }
}