using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private GameObject _generalMenuCanvasGO;
    [SerializeField] private GameObject _videoMenuCanvasGO;
    [SerializeField] private GameObject _audioMenuCanvasGO;
    [SerializeField] private GameObject _miscMenuCanvasGO;

    [Header("First Selected Buttons")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;
    [SerializeField] private GameObject _generalMenuFirst;
    [SerializeField] private GameObject _videoMenuFirst;
    [SerializeField] private GameObject _audioMenuFirst;
    [SerializeField] private GameObject _miscMenuFirst;

    private bool isPaused;

    private void Start()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void Update()
    {
       
    }

    #region Pause/Unpause Functions

    #endregion

    #region Canvas Activations/Deactivations

    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void CloseSettingsMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenGeneralMenu()
    {
        EventSystem.current.SetSelectedGameObject(_generalMenuFirst);
    }
    private void OpenVideoMenu()
    {
        EventSystem.current.SetSelectedGameObject(_videoMenuFirst);
    }
    private void OpenAudioMenu()
    {
        EventSystem.current.SetSelectedGameObject(_audioMenuFirst);
    }
    private void OpenMiscMenu()
    {
        EventSystem.current.SetSelectedGameObject(_miscMenuFirst);
    }

    #endregion

    #region Main Menu Button Actions

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }
    public void OnPlayPress()
    {
        SceneManager.LoadScene("Placeholder");
    }
    public void OnQuitPress()
    {
        Application.Quit();
    }
    public void OnBackPress()
    {
        CloseSettingsMenu();
    }
    public void OnGeneralPress()
    {
        OpenGeneralMenu();
    }
    public void OnVideoPress()
    {
        OpenVideoMenu();
    }
    public void OnAudioPress()
    {
        OpenAudioMenu();
    }
    public void OnMiscPress()
    {
        OpenMiscMenu();
    }

    #endregion
}
