using UnityEngine;

namespace Scrips
{
    public class PlayerShooter : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform shootPoint;
        public float fireInterval = 1f;
        public float bulletSpeed = 20f;

        public AudioSource audioSource;
        public AudioClip shootSound;

        private float timer;
        private float soundTimer;
        public float shootSoundInterval = 0.5f; // thời gian giữa các lần phát âm

        void Update()
        {
            timer += Time.deltaTime;
            soundTimer += Time.deltaTime;

            if (timer >= fireInterval)
            {
                Shoot();
                timer = 0f;
            }
        }

        void Shoot()
        {
            if (bulletPrefab == null || shootPoint == null) return;

            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.forward * bulletSpeed;

                // ✅ Chỉ phát âm thanh nếu đủ thời gian cách lần trước
                if (soundTimer >= shootSoundInterval && audioSource != null && shootSound != null)
                {
                    audioSource.clip = shootSound;
                    audioSource.Play();
                   
                    soundTimer = 0f;
                }
            }

            Destroy(bullet, 2f);
        }

        void StopShootSound()
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}