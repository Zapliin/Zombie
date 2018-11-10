using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    public int life = 3;
    public float hitTime = 1;

    private float tick;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            tick = Time.time + hitTime;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            if (Time.time >= tick)
            {
                tick = Time.time + 1;
                life--;
                Debug.Log("Hit!");
            }
        }
    }
}
