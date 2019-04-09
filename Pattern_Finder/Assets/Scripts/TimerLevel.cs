using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerLevel : MonoBehaviour
{
    [SerializeField] private int gameOverTime = 180;
    [SerializeField] private TextMeshProUGUI timerText = null;
    private float m_currentTime = 0;
    private int m_secondCount = 0;

    // Start is called before the first frame update
    private void Start() { m_secondCount = gameOverTime; }

    // Update is called once per frame
    private void Update()
    {
        m_currentTime += Time.deltaTime;

        if (m_secondCount <= 0)
        {
            // Game over time elapsed
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (m_currentTime >= 1.0f)
        {
            if (timerText != null)
            {
                --m_secondCount;
                // Change text of the timerText
                timerText.text = "Time left : " +m_secondCount.ToString();
            }

            m_currentTime = 0.0f;
        }
    }
}
