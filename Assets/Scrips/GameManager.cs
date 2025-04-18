using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scrips
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int coinCount = 0;

        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private GameObject gameOverPanel;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);
        }

        public void AddCoin()
        {
            coinCount++;
            if (coinText != null)
                coinText.text = "Coins: " + coinCount;
        }

        public void GameOver()
        {
            Time.timeScale = 0f;
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // ➕ Nếu cần lấy coin từ test
        public int GetCoin()
        {
            return coinCount;
        }
    }
}