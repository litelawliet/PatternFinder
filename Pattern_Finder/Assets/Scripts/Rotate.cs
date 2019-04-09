using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private int rotatedAngle = 90;
    [SerializeField] private bool rotate;
    [SerializeField] private GameObject mirror;

    void Start()
    {
        mirror = this.gameObject;

        rotate = mirror.transform.rotation.eulerAngles.z == rotatedAngle ? true : !(mirror.transform.rotation.eulerAngles.z == 0);
    }

    void Update()
    {
        mirror.transform.eulerAngles = rotate ? new Vector3(0, 0, rotatedAngle) : new Vector3(0, 0, 0);
    }

    public void ButtonActivate()
    {
        rotate = !rotate;
    }
}
