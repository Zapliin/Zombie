using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour {

    public float speed;
    private GameObject player;

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
    }

    private void SetDestination()
    {
        player = GameObject.Find("Player");
        _destination = player.transform;
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    private void Update()
    {
        SetDestination();
    }
}
