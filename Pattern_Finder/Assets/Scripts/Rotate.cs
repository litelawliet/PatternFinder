using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool rotate;
    private GameObject mirror;
    void Start()
    {
        mirror = this.gameObject;

        if (mirror.transform.rotation.z == 90)
        {
            rotate = true;
        }
        if (mirror.transform.rotation.z == 0)
        {
            rotate = false;
        }
    }

    void Update()
    {
        if (rotate == true)
        {
            mirror.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (rotate == false)
        {
            mirror.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void ButtonActivate()
    {
        rotate = !rotate;
    }
}
