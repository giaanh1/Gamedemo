using System.Collections.Generic;
using UnityEngine;

namespace Scrips
{
    public class AllyManager : MonoBehaviour
    {
        public GameObject npcPrefab;
        public Transform player;
        public List<GameObject> allies = new();

        public float spacingX = 1.2f;  // khoảng cách ngang giữa các NPC
        public float spacingZ = 1.5f;  // khoảng cách dọc giữa các hàng

        public void ChangeAllyCount(int delta)
        {
            if (delta > 0)
            {
                for (int i = 0; i < delta; i++)
                {
                    // ❌ Loại bỏ việc spawn cao hơn 1f
                    Vector3 spawnPos = player.position;
                    GameObject ally = Instantiate(npcPrefab, spawnPos, Quaternion.identity);
                    allies.Add(ally);
                }
            }
            else
            {
                for (int i = 0; i < -delta && allies.Count > 0; i++)
                {
                    GameObject ally = allies[allies.Count - 1];
                    allies.RemoveAt(allies.Count - 1);
                    Destroy(ally);
                }
            }
        }

        private void Update()
        {
            UpdateTriangleFormation();
        }

        private void UpdateTriangleFormation()
        {
            int total = allies.Count;
            int currentIndex = 0;
            int row = 0;

            while (currentIndex < total)
            {
                row++;
                int rowCount = Mathf.Min(row, total - currentIndex);
                float startX = -(rowCount - 1) * spacingX / 2f;
                float zOffset = -row * spacingZ;

                for (int i = 0; i < rowCount; i++)
                {
                    GameObject npc = allies[currentIndex];

                    // Tính vị trí mong muốn của NPC trong đội hình
                    Vector3 targetPos = player.position + new Vector3(startX + i * spacingX, 0, zOffset);
                    targetPos.y = npc.transform.position.y; // giữ nguyên chiều cao NPC

                    // Di chuyển mượt đến vị trí
                    Vector3 smoothPos = Vector3.Lerp(npc.transform.position, targetPos, Time.deltaTime * 5f);
                    npc.transform.position = smoothPos;

                    // NPC nhìn về hướng Player
                    npc.transform.LookAt(player.position + Vector3.forward * 5f);

                    currentIndex++;
                }
            }
        }
    }
}
