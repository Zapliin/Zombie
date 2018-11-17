using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponProperties : MonoBehaviour {

    public Transform playerTransform;
    public GameObject bulletPrefab;
    public Text ammoText;

    //Weapon Properties
    public int damage;
    public float speed;
    private float fireRate;
    private int bullets;
    private int magazines;
    private int bulletsLoaded;
    private int bulletsInMagazine;
    private float reloadTime;

    private bool startShooting = false;
    private float tick;
    private Transform firePoint;
    private Vector3 initialPos;
    private float firePosX;
    private float firePosZ;

    void Start()
    {
        Pick();
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

        if (Input.GetKeyDown("r"))
        {
            Reload();
        }
        
        ammoText.text = bulletsLoaded.ToString() + " / " + bulletsInMagazine.ToString();
    }

    public void Pick(string weaponEqquiped = "Pistol")
    {
        GameObject weapon = GameObject.Find(weaponEqquiped);
        Weapon weaponProperties = weapon.GetComponent<Weapon>();
        damage = weaponProperties.damage;
        fireRate = weaponProperties.fireRate;
        speed = weaponProperties.speed;
        bullets = weaponProperties.bullets;
        magazines = weaponProperties.magazines;
        reloadTime = weaponProperties.reloadTime;
        bulletsLoaded = bullets;
        bulletsInMagazine = bullets * (magazines - 1);
        ammoText.color = new Color(255, 255, 255, 255);
    }

    public void Shoot()
    {
        if (bulletsLoaded > 0)
        {
            bulletsLoaded--;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Reload();
        }
    }

    void Reload()
    {
        if (bulletsInMagazine > 0)
        {
            int difference;
            difference = bullets - bulletsLoaded;
            bulletsLoaded += difference;
            bulletsInMagazine -= difference;
        }
        else if (bulletsInMagazine == 0 && bulletsLoaded == 0)
        {
            ammoText.color = new Color(255, 0, 0, 255);
            Debug.Log("Out of ammo");
        }
    }

}
