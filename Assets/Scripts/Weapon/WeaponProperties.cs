﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProperties : MonoBehaviour {

    public Transform playerTransform;
    public GameObject bulletPrefab;
    public float fireRate = 1f;

    private bool startShooting = false;
    public float tick;
    private Transform firePoint;
    private Vector3 initialPos;
    private float firePosX;
    private float firePosZ;

    void Start()
    {
        firePoint = GetComponent<Transform>();
        initialPos = firePoint.position;
    }

    void Update () {
        float AimVertical = Input.GetAxisRaw("AimVertical");
        float AimHorizontal = Input.GetAxisRaw("AimHorizontal");

        firePoint.position = new Vector3(firePosX, firePoint.position.y, firePosZ);

        if ((AimHorizontal != 0 || AimVertical != 0) && !startShooting)
        {
            Shoot();
            tick = Time.time + fireRate;
            startShooting = true;
        }

        if (AimHorizontal != 0)
        {       
            firePosX = playerTransform.position.x + initialPos.x * AimHorizontal;
            firePosZ = playerTransform.position.z + initialPos.z * AimHorizontal;
            if(Time.time >= tick)
            {
                Shoot();
                tick = Time.time + fireRate;
            } 
        }

        if (AimVertical != 0)
        {
            firePosX = playerTransform.position.x + initialPos.z * AimVertical;
            firePosZ = playerTransform.position.z + initialPos.x * AimVertical;
            if (Time.time >= tick)
            {
                Shoot();
                tick = Time.time + fireRate;
            }
        }

        if (AimHorizontal == 0 && AimVertical == 0)
        {
            tick = 0;
            startShooting = false;
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}