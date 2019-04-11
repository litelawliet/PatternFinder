using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonLethalLaser : MonoBehaviour
{
    [SerializeField] private string NameOfLaser = "";

    [Range(0, 0.1f)]
    [SerializeField] private float speed = 0;

    [SerializeField] GameObject Xcrank = null;
    [SerializeField] GameObject Ycrank = null;

    private GameObject laserPointer;
    
    private void Start()
    {
        laserPointer = GameObject.Find(NameOfLaser);
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
        }
    }

}
