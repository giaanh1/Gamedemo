using UnityEngine;

namespace Scrips
{
    public class PlayerRunner : MonoBehaviour
    {
        public float speed = 10f;
        public float laneDistance = 2.5f;
        public float gravity = -20f;
        public float jumpForce = 10f;

        private float verticalVelocity = 0f;
        private int currentLane = 1;
        private CharacterController controller;
        private Vector3 direction;
        private PlayerAnimation playerAnim;

        // ======= Thêm vào đây =======
        private float speedIncreaseInterval = 20f;
        private float nextSpeedIncreaseTime = 0f;
        private float speedIncrement = 2f;
        private Renderer playerRenderer;
        private Color originalColor;
        private float flashDuration = 0.3f;
        private float flashTimer = 0f;
        // ============================

        void Start()
        {
            controller = GetComponent<CharacterController>();
            playerAnim = GetComponent<PlayerAnimation>();

            // ======= Hiệu ứng flash khi tăng tốc =======
            playerRenderer = GetComponentInChildren<Renderer>();
            if (playerRenderer != null)
            {
                originalColor = playerRenderer.material.color;
            }

            nextSpeedIncreaseTime = Time.time + speedIncreaseInterval;
            // ============================================
        }

        void Update()
        {
            direction.z = speed;

            // Gravity xử lý
            if (controller.isGrounded)
            {
                verticalVelocity = -1f;
            }
            else
            {
                verticalVelocity += gravity * Time.deltaTime;
            }

            // Nhảy
            if ((Input.GetKeyDown(KeyCode.Space) || SwipeManager.swipeUp) && controller.isGrounded)
            {
                verticalVelocity = jumpForce;
                if (playerAnim != null) playerAnim.Jump();
                Debug.Log("JUMP! verticalVelocity = " + verticalVelocity);
            }

            // Rơi nhanh
            if (!controller.isGrounded && SwipeManager.swipeDown)
            {
                verticalVelocity = -30f;
                Debug.Log("Swipe xuống khi đang nhảy → rơi nhanh!");
            }

            direction.y = verticalVelocity;

            // Di chuyển lane
            if (SwipeManager.swipeRight)
            {
                MoveLane(1);
                if (playerAnim != null) playerAnim.StepRight();
            }

            if (SwipeManager.swipeLeft)
            {
                MoveLane(-1);
                if (playerAnim != null) playerAnim.StepLeft();
            }

            // Tính vị trí theo lane
            Vector3 targetPos = transform.position;
            targetPos.z = transform.position.z;
            if (currentLane == 0) targetPos.x = -laneDistance;
            else if (currentLane == 1) targetPos.x = 0;
            else if (currentLane == 2) targetPos.x = laneDistance;

            Vector3 move = Vector3.zero;
            move.x = (targetPos.x - transform.position.x) * 10f;
            move.y = direction.y;
            move.z = direction.z;

            controller.Move(move * Time.deltaTime);

            // ========== Tăng tốc độ sau mỗi 5 giây ==========
            if (Time.time >= nextSpeedIncreaseTime)
            {
                speed += speedIncrement;
                nextSpeedIncreaseTime = Time.time + speedIncreaseInterval;
                Debug.Log("Tăng tốc độ! Speed mới: " + speed);

                if (playerRenderer != null)
                {
                    playerRenderer.material.color = Color.yellow; // Flash vàng
                    flashTimer = flashDuration;
                }
            }

            // ========== Xử lý hiệu ứng chớp sáng ==========
            if (flashTimer > 0f)
            {
                flashTimer -= Time.deltaTime;
                if (flashTimer <= 0f && playerRenderer != null)
                {
                    playerRenderer.material.color = originalColor;
                }
            }
        }

        void MoveLane(int direction)
        {
            currentLane += direction;
            currentLane = Mathf.Clamp(currentLane, 0, 2);
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Chạm Obstacle!");
                if (GameManager.instance != null)
                {
                    GameManager.instance.GameOver();
                }
            }
        }
    }
}
