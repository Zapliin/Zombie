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

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        properties = GetComponent<ZombieProperties>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        _navMeshAgent.updateRotation = false;
    }

    private void SetDestination()
    {
        if (properties.dead == false)
        {
            player = GameObject.Find("Player");
            _destination  = player.transform;
            if (_destination != null)
            {
                Vector3 targetVector = _destination.transform.position;
                _navMeshAgent.SetDestination(targetVector);
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
