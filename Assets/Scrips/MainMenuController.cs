using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject instructionsPanel; // Panel chứa hướng dẫn

    public void StartGame()
    {
        // Tải scene chơi chính (đảm bảo đã add vào Build Settings)
        SceneManager.LoadScene("GameScene"); // 🔁 thay bằng tên scene thật
    }

    public void ShowInstructions()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit();
    }

    public void CloseInstructions()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);
    }
}