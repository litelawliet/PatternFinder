using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class CatLaserFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform = null;
    [SerializeField] private float     catSpeed        = 3.0f;
    private                  Vector3   m_direction;
    private                  float     m_distance;
    float                              m_wallDistance = 0.0f;

    private void Update()
    {
        var targetPosition = targetTransform.position;
        var catPosition    = transform.position;
        m_direction = new Vector3(targetPosition.x - catPosition.x, targetPosition.y - catPosition.y, 0.0f);

        RaycastHit hit;
        m_distance = m_direction.magnitude;

        if (Physics.Raycast(transform.position, transform.TransformDirection(m_direction), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(m_direction) * hit.distance, Color.yellow);
            m_wallDistance = Vector3.Distance(hit.point, catPosition);

            if (m_distance < m_wallDistance)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                transform.Translate(m_direction.normalized * catSpeed * Time.deltaTime);
            }
        }
    }
}