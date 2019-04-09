﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMain : MonoBehaviour
{
    private LineRenderer m_lineRenderer;
    private Vector3[] m_hitPoints;
    private Vector3[] m_hitNormals;
    private float lastTime;
    public Transform laserStart;

    public bool turnedOn;
    public int posNb;

    void Start()
    {
        lastTime = 0;
        posNb = 1;
        m_hitPoints = new Vector3[10];
        m_hitNormals = new Vector3[10];
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {

        m_hitPoints[0] = laserStart.position;
        m_hitNormals[0] = laserStart.right;

        posNb = 1;
        for (int i = 0; i < m_hitPoints.Length; i++)
        {
            RaycastHit lineHit;

            if (Physics.Raycast(m_hitPoints[i], m_hitNormals[i], out lineHit))
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

        if (Time.time > lastTime)
        {
            for (int j = 1; j < posNb; ++j)
            {
                float distance = Vector3.Distance(m_hitPoints[j - 1], m_hitPoints[j]);

                for (float x = 0; x < distance; x += 0.01f)
                {
                    Vector3 pointA = m_hitPoints[j - 1];
                    Vector3 pointB = m_hitPoints[j];

                    Vector3 finalPoint = (x * Vector3.Normalize(pointB - pointA)) + pointA;
                    m_lineRenderer.positionCount = j + 1;
                    m_lineRenderer.SetPosition(j, finalPoint);
                }

                //m_lineRenderer.SetPositions(m_hitPoints);
            }

            lastTime = Time.time + 0.1f;
        }
    }
}
