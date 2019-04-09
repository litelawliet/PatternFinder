using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private bool rotate;
    [SerializeField] private GameObject mirror;

    void Start()
    {
        mirror = this.gameObject;

        rotate = mirror.transform.rotation.eulerAngles.z == 90 ? true : mirror.transform.rotation.eulerAngles.z == 0 ? false : true;
    }

    void Update()
    {
        mirror.transform.eulerAngles = rotate ? new Vector3(0, 0, 90) : new Vector3(0, 0, 0);
    }

    public void ButtonActivate()
    {
        rotate = !rotate;
    }
}
