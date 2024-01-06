using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSettingsScreen : MonoBehaviour
{
    public GameObject[] m_mainButtons;

    public GameObject m_controlsPanel;
    public GameObject m_areYouSurePanel;
    public GameObject m_gameResetPanel;

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN);
    }

    public void ShowControls()
    {
        SetMainButtonsActive(false);
        m_controlsPanel.SetActive(true);
    }

    public void HideControls()
    {
        m_controlsPanel.SetActive(false);
        SetMainButtonsActive(true);
    }

    public void ShowAreYouSurePanel()
    {
        SetMainButtonsActive(false);
        m_areYouSurePanel.SetActive(true);
    }

    public void HideAreYouSurePanel()
    {
        m_areYouSurePanel.SetActive(false);
        SetMainButtonsActive(true);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        CThemeManager.Instance.m_themeID = C.THEME_ID_BASIC;
        ShowGameResetPanel();
    }

    private void ShowGameResetPanel()
    {
        m_areYouSurePanel.SetActive(false);
        m_gameResetPanel.SetActive(true);
    }

    public void HideGameResetPanel()
    {
        m_gameResetPanel.SetActive(false);
        SetMainButtonsActive(true);
    }

    private void SetMainButtonsActive(bool bActive)
    {
        foreach (GameObject button in m_mainButtons)
        {
            button.SetActive(bActive);
        }
    }
}
