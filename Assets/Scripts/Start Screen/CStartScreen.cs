using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CStartScreen : MonoBehaviour
{
    [SerializeField]
    private Image m_playerImage;

    private void Start()
    {
        CThemeManager.Instance.m_themeID = C.THEME_ID_CLASSIC_PIXEL; //To do: remove this and implement button on themes page
        m_playerImage.sprite = CThemeManager.CurrentPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(C.SCENE_ID_GAME);
    }

    public void ShowThemes()
    {
        SceneManager.LoadScene(C.SCENE_ID_THEMES);
    }

    public void Settings()
    {
        SceneManager.LoadScene(C.SCENE_ID_SETTINGS);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
