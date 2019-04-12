using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool open;
    [SerializeField] private Vector3 DoorPos;
    [SerializeField] private Vector3 DoorOpen;
    [SerializeField] private Vector3 DoorClose;
    [SerializeField] private int reculPorte = -100;

    private void Start()
    {
        DoorPos = gameObject.transform.position;
        DoorOpen = new Vector3(DoorPos.x, DoorPos.y, DoorPos.z);
        DoorClose = new Vector3(DoorPos.x, DoorPos.y, reculPorte);
        open = DoorPos == DoorOpen || !(DoorPos == DoorClose);
    }

    private void Update()
    {
        DoorPos = open ? DoorOpen : DoorClose;
        gameObject.transform.position = DoorPos;
    }

    public void DoorActivate()
    {
        FindObjectOfType<AudioManager>().Play("DoorOpening");
        open = !open;
    }
}
