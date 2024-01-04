using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class CSkinsScreen : MonoBehaviour
{
    private int m_tempSkinID = C.SKIN_ID_BASIC;

    private void Start()
    {
        //Retrieve all skin buttons and select the one that's currently active
        Button[] buttons = GetComponentsInChildren<Button>();
        buttons = buttons.Where(butt => butt.tag == "SkinButton").ToArray();
        buttons[CSkinManager.Instance.m_skinID].Select();
    }

    public void OK()
    {
        CSkinManager.Instance.m_skinID = m_tempSkinID;
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN);
    }

    public void Cancel()
    {
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN);
    }

    public void SetSkinToBasic()
    {
        m_tempSkinID = C.SKIN_ID_BASIC;
    }
    
    public void SetSkinToHanddrawn()
    {
        m_tempSkinID = C.SKIN_ID_HANDDRAWN;
    }
}
