using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private GameObject levelSelect;
    [SerializeField]
    private GameObject options;
    Animator animStart;
    Animator animOptions;
    Animator animLevel;
    public static GameObject currentCanvas;

    public void Start()
    {
        animStart = start.GetComponent<Animator>();
        animOptions = options.GetComponent<Animator>();
        animLevel = levelSelect.GetComponent<Animator>();
        Debug.Log(currentCanvas);
    }

    public void Play()
    {
        animStart.SetTrigger("SwitchStart");
        SceneManager.LoadScene("Level1_Scene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Options()
    {
        animStart.SetTrigger("SwitchStart");
        animOptions.SetTrigger("SwitchOptions");
        currentCanvas = options;
        options.GetComponent<Canvas>().sortingOrder = 3;
        Debug.Log(currentCanvas.name);
    }

    public void LevelSelect()
    {
        animStart.SetTrigger("SwitchStart");
        animLevel.SetTrigger("SwitchLevel");
        currentCanvas = levelSelect;
        levelSelect.GetComponent<Canvas>().sortingOrder = 3;
        Debug.Log(currentCanvas.name);
    }

    public void Back()
    {
        name = currentCanvas.name;
        currentCanvas.GetComponent<Animator>().SetTrigger("Switch" + name + "Reverse");
        animStart.SetTrigger("SwitchStartReverse");
        options.GetComponent<Canvas>().sortingOrder = 0;
        levelSelect.GetComponent<Canvas>().sortingOrder = 1;
    }
}
