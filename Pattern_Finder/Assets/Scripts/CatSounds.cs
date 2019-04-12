using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSounds : MonoBehaviour
{
    private int ran;

    void Start()
    {
        Meow();
    }

    IEnumerator Meow()
    {
        yield return new WaitForSeconds(5);
        ran = Random.Range(0, 4);
        if (ran == 0)
            FindObjectOfType<AudioManager>().Play("KittyMeow1");
        if (ran== 1)
            FindObjectOfType<AudioManager>().Play("KittyMeow2");
        if (ran == 2)
            FindObjectOfType<AudioManager>().Play("KittyMeow3");
        if (ran == 3)
            FindObjectOfType<AudioManager>().Play("KittyMeow4");
    }
}
