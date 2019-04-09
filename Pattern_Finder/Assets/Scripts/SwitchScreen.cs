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

    public void Start()
    {
        start.SetActive(true);
        levelSelect.SetActive(false);
        options.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1_Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        options.SetActive(true);
        start.SetActive(false);
    }

    public void LevelSelect()
    {
        start.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Back()
    {
        options.SetActive(false);
        levelSelect.SetActive(false);
        start.SetActive(true);
    }
}
