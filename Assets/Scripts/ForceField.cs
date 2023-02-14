using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ForceField : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float radius;
    [SerializeField] private float timeIncrease;


    private void Update()
    {
        Vector3 pos = transform.position;
        
        material.SetVector("_MaskPos", new Vector4(pos.x, pos.y, pos.z, radius));
        material.SetTextureOffset("_forceTexture", new Vector2(Time.time * timeIncrease, 0.0f));
   //     material.SetFloat("_GameTime", Time.time);
    }
}
