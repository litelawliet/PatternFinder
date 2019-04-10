using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankMechanic : MonoBehaviour
{

    [SerializeField] private string m_crankTag = "";

    private GameObject m_crankGameObject;
    private Vector3 m_angleVectorWithCrank;
    private float m_baseAngle;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.collider.gameObject.CompareTag(m_crankTag))
                {
                    m_crankGameObject = hit.collider.gameObject;
                    m_baseAngle = Vector3.Angle((Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - m_crankGameObject.transform.position).normalized, m_crankGameObject.transform.up.normalized);
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(m_crankGameObject != null)
            {
                Vector3 Mousepos = Input.mousePosition;
                Mousepos.z = 10;
                Vector3 MousePosScreen = Camera.main.ScreenToWorldPoint(Mousepos);


                m_angleVectorWithCrank = MousePosScreen - m_crankGameObject.transform.position;
                m_angleVectorWithCrank.Normalize();
                Vector3 finalVector = Quaternion.Euler(0, 0, -90) * m_angleVectorWithCrank;

                float Angle = Vector3.Angle(m_angleVectorWithCrank, m_crankGameObject.transform.up.normalized);
                float dotProduct = Vector3.Dot(finalVector, m_crankGameObject.transform.up);

                if(dotProduct > 0)
                {
                    m_crankGameObject.transform.Rotate(0, 0, Angle - m_baseAngle);
                    m_crankGameObject.GetComponent<Crank>().ResultAngle += Angle - m_baseAngle;
                }
                if(dotProduct < 0)
                {
                    m_crankGameObject.transform.Rotate(0, 0, -(Angle - m_baseAngle));
                    m_crankGameObject.GetComponent<Crank>().ResultAngle += -(Angle - m_baseAngle);
                }



            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            m_crankGameObject = null;
        }
    }
}
