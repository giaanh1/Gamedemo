using UnityEngine;

namespace Scrips
{
    public class AllyFollower : MonoBehaviour
    {
        public Transform followTarget;
        public float followDistance = 2f;
        public float moveSpeed = 5f;

        void Update()
        {
            if (followTarget == null) return;

            // Tính vị trí mong muốn
            Vector3 targetPos = followTarget.position - followTarget.forward * followDistance;

            // Giữ nguyên Y để không bị chôn xuống mặt đất
            targetPos.y = transform.position.y;

            // Di chuyển mượt đến target
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);

            // NPC nhìn về hướng chạy
            transform.LookAt(followTarget.position + Vector3.forward * 10f);
        }
    }
}