using UnityEngine;

namespace Scrips
{
    public class Coin : MonoBehaviour
    {
        public AudioClip pickupSound; // ✅ Âm thanh thu thập

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // ✅ Phát âm thanh (từ AudioSource của Player)
                AudioSource playerAudio = other.GetComponent<AudioSource>();
                if (playerAudio != null && pickupSound != null)
                {
                    playerAudio.PlayOneShot(pickupSound);
                }

                // ✅ Tăng coin
                GameManager.instance.AddCoin();

                // ✅ Xoá coin khỏi scene
                Destroy(gameObject);
            }
        }
    }
}