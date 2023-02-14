using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundToggle : MonoBehaviour
{
    [SerializeField] private LightSourceRotate lightSourceRotate;
    [SerializeField] private Material groundMaterial;
    [SerializeField] private GameObject forceField;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color desertColor;

    private bool _isDesert;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lightSourceRotate.enabled = !lightSourceRotate.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            groundMaterial.SetColor("_Color", _isDesert ? greenColor : desertColor);
            _isDesert = !_isDesert;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            forceField.SetActive(!forceField.activeInHierarchy);
        }
    }
}
