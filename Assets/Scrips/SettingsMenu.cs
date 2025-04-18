using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scrips
{
    public class SettingsMenu : MonoBehaviour
    {
        public GameObject settingsPanel;
        public Button settingsButton;
        public Slider volumeSlider;
        public Button backToMenuButton;

        private bool panelVisible = false;

        void Start()
        {
            settingsPanel.SetActive(false); // Ẩn panel lúc đầu

            settingsButton.onClick.AddListener(ToggleSettingsPanel);
            volumeSlider.onValueChanged.AddListener(AdjustVolume);
            backToMenuButton.onClick.AddListener(ReturnToMenu);

            volumeSlider.value = AudioListener.volume;
        }

        void ToggleSettingsPanel()
        {
            panelVisible = !panelVisible;
            settingsPanel.SetActive(panelVisible);
        }

        void AdjustVolume(float value)
        {
            AudioListener.volume = value;
            Debug.Log("Âm lượng: " + value);
        }

        void ReturnToMenu()
        {
            SceneManager.LoadScene("Menu"); // Đổi tên scene nếu khác
        }
    }
}