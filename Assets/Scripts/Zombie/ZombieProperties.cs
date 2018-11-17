using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieProperties : MonoBehaviour {

    public int health = 100;
    public bool dead;
    private GameObject roundCounter;
    private RoundCounter roundCounterScript;
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
        roundCounter = GameObject.Find("RoundCounter");
        roundCounterScript = roundCounter.GetComponent<RoundCounter>();

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
        roundCounterScript = roundCounter.GetComponent<RoundCounter>();
        score.DieScore();
        dead = true;
        animator.SetBool("Dead", dead);
        
        roundCounterScript.KillCount();
        navMeshAgent.enabled = false;
        collider.enabled = false;
        //Destroy(gameObject);
    }
}
