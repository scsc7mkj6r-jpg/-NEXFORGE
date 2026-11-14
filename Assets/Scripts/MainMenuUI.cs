using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Menu Buttons")]
    public Button playButton;
    public Button settingsButton;
    public Button exitButton;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject settingsPanel;

    private void Start()
    {
        if (playButton != null)
            playButton.onClick.AddListener(PlayGame);

        if (settingsButton != null)
            settingsButton.onClick.AddListener(OpenSettings);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        if (mainPanel != null)
            mainPanel.SetActive(false);

        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (mainPanel != null)
            mainPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}