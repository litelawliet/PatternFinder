using UnityEngine;

public class CrankMechanic : MonoBehaviour
{
    [SerializeField] private string m_crankTag = "";

    private GameObject m_crankGameObject;
    private Vector3 m_angleVectorWithCrank;
    private float m_baseAngle;
    private Camera m_camera;
    private int ran;

    private void Start()
    {
        m_camera = Camera.main;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(m_camera != null && Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.collider.gameObject.CompareTag(m_crankTag))
                {
                    m_crankGameObject = hit.collider.gameObject;
                    m_baseAngle = Vector3.Angle((m_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - m_crankGameObject.transform.position).normalized, m_crankGameObject.transform.up.normalized);
                }
            }
        }
        
        if(Input.GetMouseButton(0))
        {
            if(m_crankGameObject != null)
            {
                Vector3 mousepos = Input.mousePosition;
                mousepos.z = 10;
                Vector3 mousePosScreen = m_camera.ScreenToWorldPoint(mousepos);

                m_angleVectorWithCrank = mousePosScreen - m_crankGameObject.transform.position;
                m_angleVectorWithCrank.Normalize();
                Vector3 finalVector = Quaternion.Euler(0, 0, -90) * m_angleVectorWithCrank;

                var up = m_crankGameObject.transform.up;
                float angle = Vector3.Angle(m_angleVectorWithCrank, up.normalized);
                float dotProduct = Vector3.Dot(finalVector, up);

                if(dotProduct > 0)
                {
                    m_crankGameObject.transform.Rotate(0, 0, angle - m_baseAngle);
                    m_crankGameObject.GetComponent<Crank>().ResultAngle += angle - m_baseAngle;
                }
                if(dotProduct < 0)
                {
                    m_crankGameObject.transform.Rotate(0, 0, -(angle - m_baseAngle));
                    m_crankGameObject.GetComponent<Crank>().ResultAngle += -(angle - m_baseAngle);
                }
                ran = Random.Range(0, 1);
                if (ran == 0)
                    FindObjectOfType<AudioManager>().Play("Crank1");
                if (ran == 1)
                    FindObjectOfType<AudioManager>().Play("Crank2");
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            m_crankGameObject = null;
        }
    }
}
