using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject start = null;
    [SerializeField]
    private GameObject levelSelect = null;
    [SerializeField]
    private GameObject options = null;
    Animator m_animStart;
    Animator m_animOptions;
    Animator m_animLevel;
    private static GameObject m_currentCanvas;
    private static readonly int SwitchStart = Animator.StringToHash("SwitchStart");
    private static readonly int SwitchOptions = Animator.StringToHash("SwitchOptions");
    private static readonly int SwitchLevel = Animator.StringToHash("SwitchLevel");
    private static readonly int SwitchStartReverse = Animator.StringToHash("SwitchStartReverse");

    public void Start()
    {
        m_animStart = start.GetComponent<Animator>();
        m_animOptions = options.GetComponent<Animator>();
        m_animLevel = levelSelect.GetComponent<Animator>();
        // Debug.Log(m_currentCanvas);
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
        m_animStart.SetTrigger(SwitchStart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
        Application.Quit();
    }

    public void Options()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
        m_animStart.SetTrigger(SwitchStart);
        m_animOptions.SetTrigger(SwitchOptions);
        m_currentCanvas = options;
        options.GetComponent<Canvas>().sortingOrder = 3;
        // Debug.Log(m_currentCanvas.name);
    }

    public void LevelSelect()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
        m_animStart.SetTrigger(SwitchStart);
        m_animLevel.SetTrigger(SwitchLevel);
        m_currentCanvas = levelSelect;
        levelSelect.GetComponent<Canvas>().sortingOrder = 3;
        // Debug.Log(m_currentCanvas.name);
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
        name = m_currentCanvas.name;
        m_currentCanvas.GetComponent<Animator>().SetTrigger("Switch" + name + "Reverse");
        m_animStart.SetTrigger(SwitchStartReverse);
        options.GetComponent<Canvas>().sortingOrder = 0;
        levelSelect.GetComponent<Canvas>().sortingOrder = 1;
    }
}
