using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseMenu : MonoBehaviour
{
    public event Action OnClickResumeButton;
    public event Action OnMenuHide;

    [Inject] private readonly IInputControl _input;

    [Header("Pause menu")]
    [SerializeField] private GameObject _pauseMenu;

    [Header("Buttons")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    private bool _isMenuActive;

    private void OnEnable()
    {
        _input.OnCallPauseMenu += OnCallPauseMenu;

        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        _settingsButton.onClick.AddListener(ShowSettings);
        _exitButton.onClick.AddListener(GoToMenu);
    }

    private void OnDisable()
    {
        _input.OnCallPauseMenu += OnCallPauseMenu;

        _resumeButton.onClick.RemoveListener(ResumeGame);
        _restartButton.onClick.RemoveListener(RestartGame);
        _settingsButton.onClick.RemoveListener(ShowSettings);
        _exitButton.onClick.RemoveListener(GoToMenu);
    }

    private void OnCallPauseMenu()
    {
        _isMenuActive = !_isMenuActive;

        if (!_isMenuActive)
        {
            HideMenu();
        }
        else
        {
            _pauseMenu.SetActive(true);
        }
    }

    private void HideMenu()
    {
        _pauseMenu.SetActive(false);
        SettingsUI.Hide();
        OnMenuHide?.Invoke();
    }

    private void ResumeGame()
    {
        _isMenuActive = false;
        _pauseMenu.SetActive(false);

        SettingsUI.Hide();

        OnClickResumeButton?.Invoke();
    }

    private void ShowSettings()
    {
        _pauseMenu.SetActive(false);
        SettingsUI.Show();
        SettingsUI.ActivateScreenAfterClose(_pauseMenu);
    }

    private void RestartGame()
    {
        HideMenu();

        SceneLoader loader = new();
        loader.LoadLevel();
    }

    private void GoToMenu()
    {
        HideMenu();

        SceneLoader loader = new();
        loader.LoadMenu();
    }
}
