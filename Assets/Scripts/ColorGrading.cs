using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ColorGrading : MonoBehaviour
{
    [SerializeField] private Material colorGrading;
    
    public void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, colorGrading);
    }
}
