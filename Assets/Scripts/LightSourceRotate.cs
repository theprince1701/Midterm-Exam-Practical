using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceRotate : MonoBehaviour
{
    [SerializeField] private Transform lightSourceTarget;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.RotateAround(lightSourceTarget.position, Vector3.up, rotateSpeed);
    }
}
