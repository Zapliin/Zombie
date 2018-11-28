using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {

    public Text roundCounter;
    public int zombiesAmount;
    public int multiplier;

    private int zombiePerSpawn;
    private int roundNumber;
    private int killCount;
    public float endTime = 5;
    private float startTime;
    private ZombieSpawn[] spawns;

	// Use this for initialization
	void Start () {
        GameObject spawn = GameObject.Find("Spawns");
        spawns = spawn.transform.gameObject.GetComponentsInChildren<ZombieSpawn>();
        zombiePerSpawn = zombiesAmount / spawns.Length;
        roundNumber = 1;
        foreach (ZombieSpawn item in spawns)
        {
            item.zombiesAmount = zombiePerSpawn;
        }
        roundCounter.text = roundNumber.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= startTime)
        {
            startTime = 0;
            RoundStart();
        }
	}

    private void RoundStart()
    {
        roundCounter.text = roundNumber.ToString();
        foreach (ZombieSpawn item in spawns)
        {
            item.zombiesAmount = zombiePerSpawn;
        }
    }

    private void RoundFinish()
    {
        zombiesAmount *= multiplier;
        zombiePerSpawn = zombiesAmount / spawns.Length;
        roundNumber++;
        killCount = 0;
        startTime = Time.time + endTime;
    }

    public void KillCount()
    {
        killCount++;
        if (killCount == zombiesAmount)
        {            
            RoundFinish();                       
        }
    }
}
