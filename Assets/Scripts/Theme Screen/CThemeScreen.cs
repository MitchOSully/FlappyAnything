using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class CThemeScreen : MonoBehaviour
{
    private int m_tempThemeID = C.THEME_ID_BASIC;

    private void Start()
    {
        //Retrieve all theme buttons and select the one that's currently active
        Button[] buttons = GetComponentsInChildren<Button>();
        buttons = buttons.Where(butt => butt.tag == "ThemeButton").ToArray();
        buttons[CThemeManager.Instance.m_themeID].Select();
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
    }
    
    public void SetThemeToHanddrawn()
    {
        m_tempThemeID = C.THEME_ID_HANDDRAWN;
    }
}
