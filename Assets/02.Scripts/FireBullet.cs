using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GunData GunData;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform firePos;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem CartridgeEffect;
    [SerializeField] PlayerMove PlayerMove;
    [SerializeField] AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayerMove = GetComponent<PlayerMove>();
        muzzleFlash = GetComponentsInChildren<ParticleSystem>()[0];
        CartridgeEffect = GetComponentsInChildren<ParticleSystem>()[1];
        firePos = this.transform.GetChild(0).GetChild(0).GetChild(0).transform;
    }

    void Update()
    {
        if(PlayerMove.fire==true)
        {
            muzzleFlash.Play();
            CartridgeEffect.Play();
            Fire();
        }
    }
    void Fire()
    {
        Instantiate(bulletprefab,firePos.position,firePos.rotation);
        source.PlayOneShot(GunData.shotClip, 1.0f);
    }
}
