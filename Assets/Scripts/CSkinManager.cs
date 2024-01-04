using UnityEngine;

public class CSkinManager : MonoBehaviour //Singleton
{
    public static CSkinManager Instance;

    public int m_skinID = C.SKIN_ID_BASIC;
    
    [SerializeField]
    private CSkin[] m_skins;

    public static Sprite CurrentPlayer()
    {
        return Instance.m_skins[Instance.m_skinID].m_player;
    }
    public static Sprite CurrentPipe()
    {
        return Instance.m_skins[Instance.m_skinID].m_pipe;
    }
    public static Sprite CurrentRocket()
    {
        return Instance.m_skins[Instance.m_skinID].m_rocket;
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
