/* This class is based off the ParallaxBackground_0.cs script from the asset 'Free 2D Cartoon
 * Parallax Background', by CPasteGame.
 * (https://assetstore.unity.com/packages/2d/environments/free-2d-cartoon-parallax-background-205812)
 */
using UnityEngine;

[System.Serializable]
public class CBackgroundLayer
{
    public GameObject m_layer;
    public float m_fMoveSpeed;
    public Vector3 m_vStartPos;
}

public class CBackgroundController : MonoBehaviour
{
    public CBackgroundLayer[] m_aLayers;
    
    private float m_fBoundX;    
    private void Start()
    {
        float fScale = DefineBoundsAndGetScale();
        InitialiseLayers(fScale);
    }

    private void Update()
    {
        MoveLayers();
    }

    private float DefineBoundsAndGetScale()
    {
        //Use layer 0's sprite to define bounds
        SpriteRenderer renderer = m_aLayers[0].m_layer.GetComponent<SpriteRenderer>();
        float fScale = 0;
        if (renderer != null)
        {
            float fLayerHeight = renderer.sprite.bounds.size.y;
            fScale = Camera.main.orthographicSize * 2 / fLayerHeight;
            m_fBoundX = renderer.sprite.bounds.size.x * fScale; //Width of image
        }
        else
        {
            Debug.Log("ERROR: Layer should have a Sprite Renderer component");
        }

        return fScale;
    }

    private void InitialiseLayers(float fScale)
    {
        for (int ii = 0; ii < m_aLayers.Length; ii++)
        {
            //Set starting positions
            m_aLayers[ii].m_vStartPos = m_aLayers[ii].m_layer.transform.position;

            //Resize everything to fill screen
            m_aLayers[ii].m_layer.transform.localScale = new Vector3(fScale, fScale, 1);
        }
    }

    //This function is currently only capable of moving to the left
    private void MoveLayers()
    {
        for (int ii = 0; ii < m_aLayers.Length; ii++)
        {
            //Move layer along
            m_aLayers[ii].m_layer.transform.position += Vector3.left * m_aLayers[ii].m_fMoveSpeed;

            //If gone outside bounds, reset
            if (m_aLayers[ii].m_layer.transform.position.x < m_aLayers[ii].m_vStartPos.x - m_fBoundX)
            {
                m_aLayers[ii].m_layer.transform.position = m_aLayers[ii].m_vStartPos;
            }
        }
    }
}
