using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform tr;
    [SerializeField] Transform target;
    [SerializeField] float Height;
    [SerializeField] float Distance;
    [SerializeField] float Movedamping=10f;
    [SerializeField] float rotateDamping = 15f;
    public float targetOffest = 2.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    
    void LateUpdate()
    {
        var CamPos = target.position - (Vector3.forward * Distance) +
            (Vector3.up * Height);
        tr.position = Vector3.Slerp(tr.position,CamPos,Time.deltaTime*Movedamping);
        tr.rotation = Quaternion.Slerp(tr.rotation,target.rotation,Time.deltaTime*rotateDamping);
        tr.LookAt(target.position + (target.up * targetOffest));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(target.position+(target.up* targetOffest),0.1f);
        Gizmos.DrawLine(target.position+(target.up)* targetOffest, tr.position);
    }
}
