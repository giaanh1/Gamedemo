using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scrips
{
    public class UIRestartButton : MonoBehaviour
    {
        public void RestartGame()
        {
            if (GameManager.instance != null)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}