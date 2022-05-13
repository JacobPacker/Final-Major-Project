using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    public float distance = 8;
    public void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * distance);
    }
}
