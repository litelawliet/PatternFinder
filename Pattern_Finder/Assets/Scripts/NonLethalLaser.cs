using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonLethalLaser : MonoBehaviour
{
    [SerializeField] private Transform pos;
    [SerializeField] private Collider coll;
    [SerializeField] private Rigidbody laserLight;
    [SerializeField] private GameObject laserPointer;

    [Range(0, 0.1f)]
    [SerializeField] private float speed = 0;

    [SerializeField] GameObject Xcrank;
    [SerializeField] GameObject Ycrank;

    private void Start()
    {
        laserPointer = GameObject.Find("LaserPointer");
        coll = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider>();
    }
    private void Update()
    {
        transform.position = new Vector3(68 -Xcrank.GetComponent<Crank>().ResultAngle * speed, 10 -Ycrank.GetComponent<Crank>().ResultAngle * speed, -240);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.gameObject.CompareTag("Ground"))
            {
                laserPointer.GetComponent<MeshRenderer>().enabled = true;
                laserPointer.transform.position = hit.point;
            }
            else
            {
                laserPointer.GetComponent<MeshRenderer>().enabled = false;
            }

            laserPointer.AddComponent<Crank>();
        }
    }

}
