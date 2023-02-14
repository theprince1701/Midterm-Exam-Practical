using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    [SerializeField] private float heightOffset;

    private int _index;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targets[_index].position + Vector3.up * heightOffset
            , Time.deltaTime * 2f);

        float dist = (targets[_index].position - transform.position).magnitude;

        if (dist <= 6.0f)
        {
            _index++;
            _index %= targets.Length;
        }
    }
}
