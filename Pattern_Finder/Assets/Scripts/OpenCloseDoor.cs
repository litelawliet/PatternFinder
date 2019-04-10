using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseDoor : MonoBehaviour
{
    [SerializeField] private bool open;
    [SerializeField] private GameObject door;
    [SerializeField] private Color image;
    [SerializeField] private Color imageOpen = Color.green;
    [SerializeField] private Color imageClose = Color.black;

    private void Start()
    {
        door = gameObject;
        image = door.GetComponent<Image>().color;
        open = image == imageOpen || !(image == imageClose);
    }

    private void Update()
    {
        door.GetComponent<Image>().color = open ? imageOpen : imageClose;
    }

    public void DoorOpen()
    {
        open = !open;
    }
}
