using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseDoor : MonoBehaviour
{
    [SerializeField] private bool open;
    [SerializeField] private GameObject door;
    [SerializeField] private Color image;
    [SerializeField] private Color imageOpen = new Color(225, 225, 225, 255);
    [SerializeField] private Color imageClose = new Color(125,125,125,255);
    void Start()
    {
        door = this.gameObject;
        image = door.GetComponent<Image>().color;
        open = (image == imageOpen) ? true : !(image == imageClose);
        
    }
    
    void Update()
    {
        
    }
    
    public void DoorOpen()
    {
        open = !open;
    }
}
