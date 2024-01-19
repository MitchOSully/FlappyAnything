using UnityEngine;

/* Is there a better word than 'theme' here? Something like 'skin' but less squeamish?
   Here are my ideas:
     * Palette
     * Skin (too squeamish)
     * Flappy
     * World?
     * Render?
*/

[System.Serializable]
public class CTheme
{
    public Sprite m_player;
    public Sprite m_pipe;
    public Sprite m_rocket;
    public Sprite[] m_aBackgroundLayers;
    //public Sprite m_coin;
    //public Sprite m_background;
    //public Sound m_music; //Sound is not the class name. Find out what it is
}

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
    public static Sprite[] CurrentBackgroundLayers()
    {
        return Instance.m_themes[Instance.m_themeID].m_aBackgroundLayers;
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
