using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieProperties : MonoBehaviour {

    public int health = 100;
    public bool dead;
    private Animator animator;
    private CapsuleCollider collider;
    private NavMeshAgent navMeshAgent;
    private Score score;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        score.DieScore();
        dead = true;
        animator.SetBool("Dead", dead);
        navMeshAgent.enabled = false;
        collider.enabled = false;
        //Destroy(gameObject);
    }
}
