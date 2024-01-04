using UnityEngine;

/* Is there a better word than 'theme' here? Something like 'skin' but less squeamish?
   Here are my ideas:
     * Palette
     * Skin (too squeamish)
     * Flappy
*/

public class CThemeManager : MonoBehaviour //Singleton
{
    public static CThemeManager Instance;

    public int m_themeID = C.THEME_ID_BASIC;
    
    [SerializeField]
    private CTheme[] m_themes;

    public static Sprite CurrentPlayer()
    {
        return Instance.m_themes[Instance.m_themeID].m_player;
    }
    public static Sprite CurrentPipe()
    {
        return Instance.m_themes[Instance.m_themeID].m_pipe;
    }
    public static Sprite CurrentRocket()
    {
        return Instance.m_themes[Instance.m_themeID].m_rocket;
    }

    private void Awake()
    {
        if (Instance == null) //First time scene is activated
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
