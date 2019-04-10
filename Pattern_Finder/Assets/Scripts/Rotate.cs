using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private int rotatedAngle = 90;
    [SerializeField] private bool rotate;
    [SerializeField] private GameObject mirror;

    private void Start()
    {
        mirror = gameObject;

        var rotation = mirror.transform.rotation;
        rotate = Math.Abs(rotation.eulerAngles.z - rotatedAngle) < 0.1f || Math.Abs(rotation.eulerAngles.z) > 0.1f;
    }

    private void Update()
    {
        mirror.transform.eulerAngles = rotate ? new Vector3(0, 0, rotatedAngle) : new Vector3(0, 0, 0);
    }

    public void ButtonActivate()
    {
        rotate = !rotate;
    }
}
