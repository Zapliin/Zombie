﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWeapon : MonoBehaviour {

    private Text enterText;
    private int rolling = 0;
    private float tick;
    private Weapon[] weapons;
    private WeaponProperties weaponProperties;
    private int actualWeapon = 0;

    // Use this for initialization
    void Start () {
        GameObject weapon = GameObject.Find("Weapon");
        weaponProperties = weapon.GetComponent<WeaponProperties>();
        weapons = weapon.transform.gameObject.GetComponentsInChildren<Weapon>();
        enterText = GameObject.Find("RandomBoxText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rolling == 1)
        {
            enterText.text = "Rolling";
            if (tick <= Time.time)
            {
                rolling = 2;
                enterText.text = "";
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Player" && rolling == 0)
        {
            if (tick <= Time.time)
            {
                enterText.text = "(950) Presiona F para comprar";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    rolling = 1;
                    tick = Time.time + 3;
                }
            }
            
        }
        if (collider.name == "Player" && rolling == 2)
        {
            enterText.text = "Presiona F para recoger el arma";
            if (Input.GetKeyDown(KeyCode.F))
            {
                int random = Random.Range(0, weapons.Length);
                while (random == actualWeapon)
                {
                    random = Random.Range(0, weapons.Length);
                }
                actualWeapon = random;
                weaponProperties.Pick(weapons[random].getName());                
                rolling = 0;
                tick = Time.time + 3;
                enterText.text = "";
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Player")
        {
            enterText.text = "";
        }
    }
}
