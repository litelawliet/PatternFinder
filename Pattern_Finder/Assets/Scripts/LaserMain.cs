using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserMain : MonoBehaviour
{
    private                  LineRenderer m_lineRenderer;
    private                  Vector3[]    m_hitPoints;
    private                  Vector3[]    m_hitNormals;
    [SerializeField] private Transform    laserStart    = null;
    [SerializeField] private string       ReflectionTag = "";

    public bool turnedOn;
    public int  posNb;

    private void Start()
    {
        posNb          = 1;
        m_hitPoints    = new Vector3[10];
        m_hitNormals   = new Vector3[10];
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        m_hitPoints  = new Vector3[10];
        m_hitNormals = new Vector3[10];

        m_hitPoints[0]  = laserStart.position;
        m_hitNormals[0] = laserStart.right;

        posNb = 1;
        for (int i = 0; i < m_hitPoints.Length; i++)
        {
            if (Physics.Raycast(m_hitPoints[i], m_hitNormals[i], out RaycastHit lineHit))
            {
                if (lineHit.collider.gameObject.CompareTag(ReflectionTag))
                {
                    m_hitNormals[i + 1] = m_hitNormals[i]
                                          - (Vector3.Dot(2 * m_hitNormals[i], lineHit.normal) / lineHit.normal.magnitude
                                             * lineHit.normal.magnitude) * lineHit.normal;
                    m_hitPoints[i + 1] = lineHit.point;
                    posNb++;
                }
                else if (lineHit.collider.isTrigger)
                {
                    if (lineHit.collider.gameObject.CompareTag("Cat"))
                    {
                        //VICTORY EVENT
                        Debug.Log("Victory !");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                else
                {
                    m_hitPoints[i + 1] = lineHit.point;
                    posNb++;
                }
            }
            else
            {
                if (m_hitNormals[i] != Vector3.zero)
                {
                    m_hitPoints[i + 1] = m_hitPoints[i] + (m_hitNormals[i] * 100);
                    posNb++;
                }
            }
        }

        if (turnedOn)
        {
            m_lineRenderer.enabled = true;
            FindObjectOfType<AudioManager>().Play("Laser");
        }
        else
            m_lineRenderer.enabled = false;

        m_lineRenderer.positionCount = posNb;
        m_lineRenderer.SetPositions(m_hitPoints);
    }

    public void TurnOn() { turnedOn = !turnedOn; }
}