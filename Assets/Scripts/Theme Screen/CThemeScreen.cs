using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class CThemeScreen : MonoBehaviour
{
    public GameObject m_lockOverlay;

    private int m_tempThemeID = C.THEME_ID_BASIC;
    private Button[] m_buttons;
    private Button m_lastSelectedButton;

    private void Start()
    {
        //Retrieve all theme buttons
        m_buttons = GetComponentsInChildren<Button>();
        m_buttons = m_buttons.Where(butt => butt.tag == "ThemeButton").ToArray();

        UpdateLockedThemes();
        SelectActiveTheme();
    }

    private void Update()
    {
        //Keep button selected if player clicks anywhere that's NOT another button
        bool bSomethingSelected = false;
        foreach (Button button in m_buttons)
        {
            if (button == EventSystem.current.currentSelectedGameObject)
            {
                bSomethingSelected = true;
            }
        }

        if (!bSomethingSelected)
        {
            m_lastSelectedButton.Select();
        }
    }

    public void OK()
    {
        CThemeManager.Instance.m_themeID = m_tempThemeID;
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN);
    }

    public void Cancel()
    {
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN);
    }

    public void SetThemeToBasic()
    {
        m_tempThemeID = C.THEME_ID_BASIC;
        m_lastSelectedButton = m_buttons[C.THEME_ID_BASIC];
    }
    
    public void SetThemeToHanddrawn()
    {
        m_tempThemeID = C.THEME_ID_HANDDRAWN;
        m_lastSelectedButton = m_buttons[C.THEME_ID_HANDDRAWN];
    }

    private void UpdateLockedThemes()
    {
        int iHighScore = PlayerPrefs.GetInt("HighScore", 0);
        int iNumThemesUnlocked = iHighScore / 5 + 1; //New skin unlocked every 5 pipes
        for (int iButt = 0; iButt < m_buttons.Length; iButt++)
        {
            if (iButt < iNumThemesUnlocked) //Unlocked theme
            {
                RemoveLockIfExists(m_buttons[iButt]);
                m_buttons[iButt].interactable = true;
            }
            else //Locked theme
            {
                Instantiate(m_lockOverlay, m_buttons[iButt].transform);
                m_buttons[iButt].interactable = false;
            }
        }
    }

    private void RemoveLockIfExists(Button button)
    {
        foreach (Transform child in button.transform)
        {
            if (child.tag == "LockOverlay")
            {
                Destroy(child);
            }
        }
    }

    private void SelectActiveTheme()
    {
        Button activeThemeButton = m_buttons[CThemeManager.Instance.m_themeID];
        if (activeThemeButton.interactable)
        {
            activeThemeButton.Select();
            m_lastSelectedButton = activeThemeButton;
        }
        else
        {
            m_buttons[C.THEME_ID_BASIC].Select();
            SetThemeToBasic();
        }
    }
}
