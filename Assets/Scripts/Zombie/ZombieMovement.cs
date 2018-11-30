using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour {

    public float speed;

    private ZombieProperties properties;
    //private Animator animator;
    private GameObject player;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        properties = GetComponent<ZombieProperties>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }

        navMeshAgent.updateRotation = false; //Evita que el zombie rote.
    }

    private void SetDestination()
    {
        if (properties.dead == false)
        {
            player = GameObject.Find("Player");
            Transform destination  = player.transform;
            if (destination != null)
            {
                Vector3 targetVector = destination.transform.position;
                navMeshAgent.SetDestination(targetVector);
            }
        }
    }

    private void Update()
    {
        SetDestination();

        ////Animaciones
        //animator.SetFloat("VerticalSpeed", moveVertical);
        //animator.SetFloat("HorizontalSpeed", moveHorizontal);
    }
}
