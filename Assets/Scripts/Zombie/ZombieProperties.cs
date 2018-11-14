using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieProperties : MonoBehaviour {

    public int health = 100;
    public bool dead;
    private Animator animator;
    private Score score;

    private void Start()
    {
        animator = GetComponent<Animator>();
        score = GameObject.Find("Puntuacion").GetComponent<Score>();
    }

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
        //Destroy(gameObject);
        score.DieScore();
        dead = true;
        animator.SetBool("Dead", dead);
    }
}
