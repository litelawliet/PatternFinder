using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool open;
    [SerializeField] private GameObject door;
    [SerializeField] private Vector3 DoorPos;
    [SerializeField] private Vector3 DoorOpen;
    [SerializeField] private Vector3 DoorClose;
    [SerializeField] private int reculPorte = -100;

    private void Start()
    {
        door = gameObject;
        DoorPos = door.transform.position;
        DoorOpen = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
        DoorClose = new Vector3(door.transform.position.x, door.transform.position.y, reculPorte);
        open = DoorPos == DoorOpen || !(DoorPos == DoorClose);
    }

    private void Update()
    {
       door.transform.position = open ? DoorOpen : DoorClose;
       //image = transform.position = new Vector3(0, 0, 10);
    }

    public void DoorActivate()
    {
        open = !open;
    }
}
