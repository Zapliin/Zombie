﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {

    public GameObject zombiePrefab;
    public float respawnTime;
    public int zombiesAmount;

    private int oldAmount;
    private int zombiesSpawned;
    private float tick;

    // Use this for initialization
    void Start () {
        tick = Time.time + respawnTime;
        oldAmount = zombiesAmount;
    }
	
	// Update is called once per frame
	void Update () {
        Respawn();
	}

    private void Respawn()
    {
        if (oldAmount < zombiesAmount)
        {
            zombiesSpawned = 0;
            oldAmount = zombiesAmount;
        }

        if (Time.time >= tick && zombiesSpawned < zombiesAmount)
        {
            Instantiate(zombiePrefab, transform.position, transform.rotation);
            tick = Time.time + respawnTime;
            zombiesSpawned++;
        }
    }
}
