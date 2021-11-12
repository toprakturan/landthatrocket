using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFogColor : MonoBehaviour
{

    Color nightFogColor;
    public Camera mainCamera;
    
    void Start()
    {
        ColorUtility.TryParseHtmlString("#000E38", out nightFogColor);
        RenderSettings.fogColor = nightFogColor;

        mainCamera.backgroundColor = nightFogColor;
    }

    
    void Update()
    {
        
    }
}
