using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankMechanic : MonoBehaviour
{

    [SerializeField] private GameObject m_crankGameObject;
    private Vector3 angleVectorWithCrank;
    private float BaseAngle;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                m_crankGameObject = hit.collider.gameObject;

                BaseAngle = Vector3.Angle((Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - m_crankGameObject.transform.position).normalized, m_crankGameObject.transform.up.normalized);
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(m_crankGameObject != null)
            {
                Vector3 Mousepos = Input.mousePosition;
                Mousepos.z = 10;
                Vector3 MousePosScreen = Camera.main.ScreenToWorldPoint(Mousepos);


                angleVectorWithCrank = MousePosScreen - m_crankGameObject.transform.position;
                angleVectorWithCrank.Normalize();
                float Angle = Vector3.Angle(angleVectorWithCrank, m_crankGameObject.transform.up.normalized);

                if(Angle > BaseAngle)
                    m_crankGameObject.transform.Rotate(0, 0, Mathf.Abs(BaseAngle - Angle));
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            m_crankGameObject = null;
        }
    }
}
