using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankMirrorRotation : MonoBehaviour
{
    [SerializeField] private GameObject mirrorToRotate = null;
    [SerializeField] private GameObject crankAssociated = null;
    [Range(0, 1)] [SerializeField] private float rotatingSpeed = 0.1f;
    private Transform mirrorTransform = null;
    private Crank m_crankAssociated = null;

    private void Start()
    {
        if (mirrorToRotate != null)
        {
            mirrorTransform = mirrorToRotate.transform;
        }

        if (crankAssociated != null)
        {
            m_crankAssociated = crankAssociated.GetComponent<Crank>();
        }
    }

    private void Update()
    {
        if (mirrorToRotate != null && m_crankAssociated != null)
        {
            var rotation = mirrorTransform.rotation;
            mirrorTransform.rotation = Quaternion.Euler(rotation.x, rotation.y,
                m_crankAssociated.ResultAngle * rotatingSpeed);
        }
    }
}