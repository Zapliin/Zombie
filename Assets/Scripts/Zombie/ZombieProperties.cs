using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieProperties : MonoBehaviour {

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
