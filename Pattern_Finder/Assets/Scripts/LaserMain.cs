using UnityEngine;

public class LaserMain : MonoBehaviour
{
    private LineRenderer m_lineRenderer;
    private Vector3[] m_hitPoints;
    private Vector3[] m_hitNormals;
    [SerializeField] private Transform laserStart = null;

    public bool turnedOn;
    public int posNb;

    private void Start()
    {
        posNb = 1;
        m_hitPoints = new Vector3[10];
        m_hitNormals = new Vector3[10];
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {

        m_hitPoints[0] = laserStart.position;
        m_hitNormals[0] = laserStart.right;

        posNb = 1;
        for (int i = 0; i < m_hitPoints.Length; i++)
        {
            if (Physics.Raycast(m_hitPoints[i], m_hitNormals[i], out RaycastHit lineHit))
            {
                m_hitNormals[i + 1] = m_hitNormals[i] - (Vector3.Dot(2 * m_hitNormals[i], lineHit.normal) / lineHit.normal.magnitude * lineHit.normal.magnitude) * lineHit.normal;
                m_hitPoints[i + 1] = lineHit.point;
                posNb++;
            }
            else
            {
                if(m_hitNormals[i] != Vector3.zero)
                {
                    m_hitPoints[i + 1] = m_hitPoints[i] + (m_hitNormals[i] * 100);
                    posNb++;
                }
            }
        }

        if (turnedOn)
            m_lineRenderer.enabled = true;
        else
            m_lineRenderer.enabled = false;

        m_lineRenderer.positionCount = posNb;
        m_lineRenderer.SetPositions(m_hitPoints);
    }
}
