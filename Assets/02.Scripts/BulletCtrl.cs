using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float speed = 3000f;

    void Start()
    {
      rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*speed);
        Destroy(gameObject, 3f);
    }

}
