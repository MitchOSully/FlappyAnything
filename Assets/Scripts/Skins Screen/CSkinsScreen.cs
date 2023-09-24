using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSkinsScreen : MonoBehaviour
{
    public void OK()
    {
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN);
    }

    public void Cancel()
    {
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN);
    }
}
