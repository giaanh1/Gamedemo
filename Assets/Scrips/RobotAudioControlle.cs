using UnityEngine;

namespace Scrips
{
    public class RobotAudioController : MonoBehaviour
    {
        public AudioSource bgmSource;
        public AudioSource sfxSource;
        public AudioSource footstepSource;

        public AudioClip bgmClip;
        public AudioClip footstepClip;
        public AudioClip shootClip;

        private CharacterController controller;
        private bool isMoving;

        void Start()
        {
            controller = GetComponent<CharacterController>();

            // Phát nhạc nền
            if (bgmSource != null && bgmClip != null)
            {
                bgmSource.clip = bgmClip;
                bgmSource.loop = true;
                bgmSource.Play();
            }

            // Thiết lập bước chân
            if (footstepSource != null && footstepClip != null)
            {
                footstepSource.clip = footstepClip;
                footstepSource.loop = true;
            }
        }

        void Update()
        {
            if (controller != null && footstepSource != null && footstepClip != null)
            {
                // Kiểm tra nếu player đang di chuyển & grounded
                isMoving = controller.velocity.magnitude > 0.1f && controller.isGrounded;

                if (isMoving && !footstepSource.isPlaying)
                {
                    footstepSource.Play();
                }
                else if (!isMoving && footstepSource.isPlaying)
                {
                    footstepSource.Stop();
                }
            }
        }

        public void PlayShoot()
        {
            if (sfxSource != null && shootClip != null)
            {
                sfxSource.PlayOneShot(shootClip);
            }
        }
    }
}