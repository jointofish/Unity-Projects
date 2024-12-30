using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color gizmocolor = Color.red;
    public float radius = 0.1f;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmocolor;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
