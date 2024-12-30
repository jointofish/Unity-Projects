using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    [SerializeField] AudioClip hitclip;
    [SerializeField] AudioSource hitSource;
    [SerializeField] GameObject hiteffect;

    private readonly string bulletTag = "Bullet";
    private void Start()
    {
        hitSource =GetComponent<AudioSource>();
        hitclip = Resources.Load<AudioClip>("Sounds/bullet_hit_metal_enemy_4");
        hiteffect = Resources.Load<GameObject>("Effect/FlareMobile");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(bulletTag))
        {
            Destroy(collision.gameObject);
           hitSource.PlayOneShot(hitclip,1.0f);
            GameObject hiteff = Instantiate(hiteffect,
                collision.transform.position,Quaternion.identity);
            Destroy(hiteff, 2.0f);
        }
    }
}
