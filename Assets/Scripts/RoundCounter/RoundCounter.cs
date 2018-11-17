using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {

    public Text roundCounter;
    public int zombiesAmount;
    public int multiplier;

    public int zombiePerSpawn;
    public int roundNumber = 1;
    public int killCount;
    private ZombieSpawn[] spawns;

	// Use this for initialization
	void Start () {
        GameObject spawn = GameObject.Find("Spawns");
        spawns = spawn.transform.gameObject.GetComponentsInChildren<ZombieSpawn>();
        zombiePerSpawn = zombiesAmount / spawns.Length;

        foreach (ZombieSpawn item in spawns)
        {
            item.zombiesAmount = zombiePerSpawn;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //RoundFinish();
	}

    private void RoundFinish()
    {
        zombiesAmount *= multiplier;
        zombiePerSpawn = zombiesAmount / spawns.Length;

        foreach (ZombieSpawn item in spawns)
        {
            item.zombiesAmount = zombiePerSpawn;
        }
    }

    public void KillCount()
    {
        killCount++;
        if (killCount == zombiesAmount)
        {
            killCount = 0;
            RoundFinish();
            roundNumber++;
            roundCounter.text = roundNumber.ToString();
        }
    }
}
